using ValiWebsite.Models;

namespace ValiWebsite.Repository
{
	public interface ILoaiSpRepository
	{
		TLoaiSp Add(TLoaiSp loaiSp);
		TLoaiSp Update(TLoaiSp loaiSp);
		TLoaiSp Delete(String Maloai);
		TLoaiSp GetLoaiSp(String Maloai);
		IEnumerable<TLoaiSp> GetAllLoaiSps();
		
		
	}
}
