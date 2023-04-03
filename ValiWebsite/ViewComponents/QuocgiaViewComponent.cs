using Microsoft.AspNetCore.Mvc;
using ValiWebsite.Repository;

namespace ValiWebsite.ViewComponents
{
	public class QuocgiaViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
	{
		private readonly IQuocgia _quocgiaRepository;
		public QuocgiaViewComponent(IQuocgia quocgiaRepository)
		{
			_quocgiaRepository = quocgiaRepository;
		}
		public IViewComponentResult Invoke()
		{
			var quocgia = _quocgiaRepository.GetAllQuocgia().OrderBy(x => x.TenNuoc);
			return View(quocgia);
		}
	}

}
