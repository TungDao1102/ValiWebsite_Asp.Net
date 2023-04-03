using ValiWebsite.Models;

namespace ValiWebsite.Repository
{
	public class LoaiSpRepository : ILoaiSpRepository
	{
		private readonly QlbanVaLiContext _context;
		public LoaiSpRepository(QlbanVaLiContext context)
		{
			_context = context;
		}
			public TLoaiSp Add(TLoaiSp loaiSp)
		{
			throw new NotImplementedException();
		}

		public TLoaiSp Delete(string Maloai)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TLoaiSp> GetAllLoaiSps()
		{
			//throw new NotImplementedException();
			return _context.TLoaiSps;
		}

		public TLoaiSp GetLoaiSp(string Maloai)
		{
			//throw new NotImplementedException();
			return _context.TLoaiSps.Find(Maloai);
		}

		public TLoaiSp Update(TLoaiSp loaiSp)
		{
            //throw new NotImplementedException();
            _context.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }
	}
}
