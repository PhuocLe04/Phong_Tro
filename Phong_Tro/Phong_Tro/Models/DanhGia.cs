using System;
using System.Collections.Generic;

namespace Phong_Tro.Models;

public partial class DanhGia
{
    public string MaDanhGia { get; set; } = null!;

    public string MaKhachHang { get; set; } = null!;

    public string MaBaiDang { get; set; } = null!;

    public DateTime NgayDanhGia { get; set; }

    public double DiemDanhGia { get; set; }

    public string? NoiDung { get; set; }

    public virtual BaiDang MaBaiDangNavigation { get; set; } = null!;

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;
}
