using System;
using System.Collections.Generic;

namespace Phong_Tro.Models;

public partial class QuanLy
{
    public string MaQuanLy { get; set; } = null!;

    public long Cccd { get; set; }

    public string HoTen { get; set; } = null!;

    public DateTime? NgaySinh { get; set; }

    public bool? GioiTinh { get; set; }

    public string Sdt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual TaiKhoan EmailNavigation { get; set; } = null!;
}
