using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing.Printing;
using ValiWebsite.Models;
using ValiWebsite.Models.Authentication;
using ValiWebsite.ViewModels;
using X.PagedList;

namespace ValiWebsite.Controllers
{
    public class HomeController : Controller
    {
		QlbanVaLiContext db = new QlbanVaLiContext();
		private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
     //   [Authentication]
        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page == null || page < 0) ? 1 : page.Value;
            var lstsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x =>x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }
        public IActionResult SanPhamTheoLoai(String maloai, int? page) {
            int pageSize = 8;
            int pageNumber = (page == null || page < 0) ? 1 : page.Value;
            var list = db.TDanhMucSps.AsNoTracking().Where(x => x.MaLoai == maloai).OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(list, pageNumber, pageSize);
            ViewBag.maloai = maloai;
            return View(lst);
        }
        public IActionResult SanPhamTheoQuocGia (String manuoc, int? page)
        {
			int pageSize = 8;
			int pageNumber = (page == null || page < 0) ? 1 : page.Value;
			var list = db.TQuocGiums.AsNoTracking().Where(x => x.MaNuoc == manuoc).OrderBy(x => x.TenNuoc);
			PagedList<TQuocGium> lst = new PagedList<TQuocGium>(list, pageNumber, pageSize);
			ViewBag.manuoc = manuoc;
			return View(lst);
		}
		public IActionResult ProductDetail(string masp)
        {
			var sanpham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == masp);
			var Anhsp = db.TAnhSps.Where(x => x.MaSp == masp).ToList();
			var homeProductDetailViewModel = new HomeProductDetailViewModel
			{
				danhMucSp = sanpham,
				anhSps = Anhsp
			};
			return View(homeProductDetailViewModel);
        }
			public IActionResult ChiTietSanPham(string masp)
        {
            var sanpham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == masp);
            var Anhsp = db.TAnhSps.Where(x => x.MaSp == masp).ToList();
            ViewBag.AnhSp = Anhsp;
            return View(sanpham);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ThanhToan() { return View(); }
        public IActionResult GiaoDichThanhToan() { return View(); }

    }
}