using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phong_Tro.Models;
using System.Diagnostics;

namespace Phong_Tro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PhongTroContext _context;

        public HomeController(PhongTroContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string id)
        {
            var phongTroList = (from phongTro in _context.PhongTros
                                join loaiPhong in _context.LoaiPhongs on phongTro.MaLoaiPhong equals loaiPhong.MaLoaiPhong
                                join baiDang in _context.BaiDangs on phongTro.MaPhongTro equals baiDang.MaPhongTro into gj
                                from baiDang in gj.DefaultIfEmpty()
                                select new
                                {
                                    phongTro.MaPhongTro,
                                    LoaiPhong = loaiPhong.TenLoaiPhong,
                                    hinhanh = phongTro.HinhAnh,
                                    phongTro.DienTich,
                                    phongTro.SlnguoiToiDa,
                                    Gia = baiDang != null ? baiDang.GiaPhong : 0
                                }).ToList();

            ViewBag.PhongTroList = phongTroList;
            return View();
        }
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
