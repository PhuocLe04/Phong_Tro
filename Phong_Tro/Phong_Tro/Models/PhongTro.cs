using System;
using System.Collections.Generic;

namespace Phong_Tro.Models;

public partial class PhongTro
{
    public string MaPhongTro { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string Phuong { get; set; } = null!;

    public string Quan { get; set; } = null!;

    public double DienTich { get; set; }

    public string? HinhAnh { get; set; }

    public string? TienIch { get; set; }

    public int SlnguoiToiDa { get; set; }

    public int MaLoaiPhong { get; set; }

    public virtual ICollection<AnhPhongTro> AnhPhongTros { get; set; } = new List<AnhPhongTro>();

    public virtual ICollection<BaiDang> BaiDangs { get; set; } = new List<BaiDang>();

    public virtual LoaiPhong MaLoaiPhongNavigation { get; set; } = null!;
}
