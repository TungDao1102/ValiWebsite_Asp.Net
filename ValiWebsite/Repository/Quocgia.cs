using ValiWebsite.Models;

namespace ValiWebsite.Repository
{
	public class Quocgia : IQuocgia
	{
		private readonly QlbanVaLiContext _context;
		public Quocgia(QlbanVaLiContext context)
		{
			_context = context;
		}
		public TQuocGium Add(TQuocGium quocGium)
		{
			throw new NotImplementedException();
		}

		public TQuocGium Delete(string Manuoc)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TQuocGium> GetAllQuocgia()
		{
			return _context.TQuocGiums;
		}

		public TQuocGium GetQuocgia(string Manuoc)
		{
			return _context.TQuocGiums.Find(Manuoc);
		}

		public TQuocGium Update(TQuocGium quocGium)
		{
			_context.Update(quocGium);
			_context.SaveChanges();
			return quocGium;
		}
	}
}
