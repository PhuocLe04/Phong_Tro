using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Phong_Tro.Models;

namespace Phong_Tro.Controllers
{
    public class BaiDangController : Controller
    {
        private readonly PhongTroContext _context;

        public BaiDangController(PhongTroContext context)
        {
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
       
        public async Task<IActionResult> Detail(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongTro = await _context.PhongTros.FirstOrDefaultAsync(sp => sp.MaPhongTro == id);
            if (phongTro == null)
            {
                return NotFound();
            }

            var anhPhongTroList = await _context.AnhPhongTros.Where(x => x.MaPhongTro == id).ToListAsync();
            var baiDang = await _context.BaiDangs.FirstOrDefaultAsync(x => x.MaPhongTro == id);
            if (baiDang == null)
            {
                return NotFound();
            }

            var chuTro = await _context.ChuTros.FirstOrDefaultAsync(x => x.MaChuTro == baiDang.MaChuTro);
            if (chuTro == null)
            {
                return NotFound();
            }

            var danhGiaList = await _context.DanhGia.Where(dg => dg.MaBaiDang == baiDang.MaBaiDang).ToListAsync();


            ViewBag.danhGia = danhGiaList;
            ViewBag.ChuTro = chuTro;
            ViewBag.baidang = baiDang;
            ViewBag.phongTro = phongTro;
            ViewBag.Anh = anhPhongTroList;

            return View();
        }
		public async Task<IActionResult> BaiDangtheoloai(int? id)
		{
			var phongtrocontext = _context.BaiDangs.Include(s => s.MaPhongTroNavigation.MaLoaiPhongNavigation).Include(s => s.MaChuTroNavigation).Include(s => s.MaPhongTroNavigation).Where(s => s.MaPhongTroNavigation.MaLoaiPhongNavigation.MaLoaiPhong == id);
			return View(await phongtrocontext.ToListAsync());
		}
		[HttpPost]
        public async Task<IActionResult> AddDanhGia(DanhGia danhGia)
        {
            if (ModelState.IsValid)
            {
                danhGia.MaDanhGia = Guid.NewGuid().ToString(); // Tạo mã đánh giá mới
                danhGia.NgayDanhGia = DateTime.Now; // Gán ngày đánh giá là ngày hiện tại

                _context.Add(danhGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Detail), new { id = danhGia.MaBaiDang });
            }

            return RedirectToAction(nameof(Detail), new { id = danhGia.MaBaiDang });
        }
	}
}
