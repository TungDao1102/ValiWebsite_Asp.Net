using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValiWebsite.Models;
using ValiWebsite.Models.ProductModel;

namespace ValiWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            var sanPhams = (from p in db.TDanhMucSps
                            select new Product
                            {
                                MaSp = p.MaSp,
                                TenSp = p.TenSp,
                                MaLoai = p.MaLoai,
                                AnhDaiDien = p.AnhDaiDien,
                                GiaNhoNhat = p.GiaNhoNhat
                            }).ToList();
            return sanPhams;
        }
        [HttpGet("{maloai}")]
        public IEnumerable<Product> GetProductsByCategory(string maloai)
        {
            var sanPhams = (from p in db.TDanhMucSps
                            where p.MaLoai == maloai
                            select new Product
                            {
                                MaSp = p.MaSp,
                                TenSp = p.TenSp,
                                MaLoai = p.MaLoai,
                                AnhDaiDien = p.AnhDaiDien,
                                GiaNhoNhat = p.GiaNhoNhat
                            }).ToList();
            return sanPhams;
        }

    }
}
