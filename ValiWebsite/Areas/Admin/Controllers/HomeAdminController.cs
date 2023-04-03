using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ValiWebsite.Models;
using X.PagedList;

namespace ValiWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Route("homeadmin/[action]")]
    public class HomeAdminController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        public IActionResult Index()
        {
            return View();
        }

      //  [Route("DanhMucSanPham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page == null || page < 0) ? 1 : page.Value;
            var lstsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGiums.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(TDanhMucSp sp)
        {
            if(ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sp);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sp);
        }

        [HttpGet]
        public IActionResult SuaSanPham(string masp) {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGiums.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            var sanpham = db.TDanhMucSps.Find(masp);
            return View(sanpham);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucSp sp)
        {
            if (ModelState.IsValid)
            {
                //  db.Update(sp);
                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sp);
        }

        [HttpGet]
        public IActionResult XoaSanPham(string masp)
        {
            TempData["Message"] = "";
            var chiTietSanPhams = db.TChiTietSanPhams.Where(x => x.MaSp == masp).ToList();
            if(chiTietSanPhams.Count() > 0)
            {
                TempData["Message"] = "Không thể xóa sản phẩm này vì đã có trong đơn hàng";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            var anhSanPhams = db.TAnhSps.Where(x => x.MaSp == masp);
            if(anhSanPhams.Any()) db.RemoveRange(anhSanPhams);
            db.Remove(db.TDanhMucSps.Find(masp));
            db.SaveChanges();
            TempData["Message"] = "Deleted";
            return RedirectToAction("DanhMucSanPham");
        }
       
    }

}
