using System;
using System.Collections.Generic;

namespace Phong_Tro.Models;

public partial class NhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string? Cccd { get; set; }

    public string? HoTen { get; set; }

    public DateTime? NgaySinh { get; set; }

    public bool? GioiTinh { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public virtual TaiKhoan? EmailNavigation { get; set; }
}
