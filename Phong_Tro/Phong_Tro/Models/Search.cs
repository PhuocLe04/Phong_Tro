using Microsoft.AspNetCore.Mvc;
using Phong_Tro.Models;

namespace Phong_Tro2.Models
{
    public class Search : ViewComponent
    {
        private readonly PhongTroContext _context;

        public Search(PhongTroContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {

            return View(_context.BaiDangs.ToList());
        }
    }
}
