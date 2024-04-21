using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phong_Tro.Models;

public class TimKiemPhongTroController : Controller
{
    private readonly PhongTroContext _context;

    public TimKiemPhongTroController(PhongTroContext context)
    {
        _context = context;
    }
    public IActionResult TimKiemPhongTro(string quan, string phuong, string diaChi)
    {
        IQueryable<BaiDang> baiDangQuery = _context.BaiDangs
                                                .Include(b => b.MaPhongTroNavigation)
                                                    .ThenInclude(p => p.MaLoaiPhongNavigation);

        if (!string.IsNullOrEmpty(quan))
        {
            // Thực hiện tìm kiếm theo quận
            baiDangQuery = baiDangQuery.Where(b => b.MaPhongTroNavigation.Quan.Contains(quan));
        }

        if (!string.IsNullOrEmpty(phuong))
        {
            // Thực hiện tìm kiếm theo phường
            baiDangQuery = baiDangQuery.Where(b => b.MaPhongTroNavigation.Phuong.Contains(phuong));
        }

        if (!string.IsNullOrEmpty(diaChi))
        {
            // Thực hiện tìm kiếm theo địa chỉ
            baiDangQuery = baiDangQuery.Where(b => b.MaPhongTroNavigation.DiaChi.Contains(diaChi));
        }

        var baiDangList = baiDangQuery.ToList();
        return View(baiDangList);
    }

}
