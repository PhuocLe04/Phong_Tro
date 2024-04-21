using Microsoft.AspNetCore.Mvc;
using Phong_Tro.Models;

namespace Phong_Tro2.Models
{
	public class Narbar:ViewComponent
	{
		private readonly PhongTroContext _context;

		public Narbar(PhongTroContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{

			return View(_context.LoaiPhongs.ToList());
		}
	}
}
