using System;
using System.Collections.Generic;

namespace Phong_Tro.Models;

public partial class KhachHang
{
    public string MaKhachHang { get; set; } = null!;

    public long Cccd { get; set; }

    public string HoTen { get; set; } = null!;

    public DateTime? NgaySinh { get; set; }

    public bool? GioiTinh { get; set; }

    public string Sdt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<DanhGia> DanhGia { get; set; } = new List<DanhGia>();

    public virtual TaiKhoan EmailNavigation { get; set; } = null!;
}
