using Microsoft.AspNetCore.Mvc;
using ValiWebsite.Repository;
using Microsoft.EntityFrameworkCore;
namespace ValiWebsite.ViewComponent

{
	public class LoaiSpMenuViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
	{
		private readonly ILoaiSpRepository _loaiSpRepository;
		public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository)
		{
			_loaiSpRepository = loaiSpRepository;
		}
		public IViewComponentResult Invoke()
		{
            var loaiSps = _loaiSpRepository.GetAllLoaiSps().OrderBy(x => x.Loai);
            return View(loaiSps);
		}
	}
}
