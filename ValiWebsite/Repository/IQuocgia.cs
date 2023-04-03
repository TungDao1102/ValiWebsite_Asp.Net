using ValiWebsite.Models;

namespace ValiWebsite.Repository
{
	public interface IQuocgia
	{
		TQuocGium Add(TQuocGium quocGium);
		TQuocGium Update(TQuocGium quocGium);
		TQuocGium Delete(String Manuoc);
		TQuocGium GetQuocgia(String Manuoc);
		IEnumerable<TQuocGium> GetAllQuocgia();
	}
}
