using Microsoft.AspNetCore.Mvc;
using Phong_Tro.Models;

namespace Phong_Tro2.Models
{
	public class Sidebar : ViewComponent
	{
		private readonly PhongTroContext _context;

		public Sidebar(PhongTroContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{

			return View(_context.LoaiPhongs.ToList());
		}
	}
}
