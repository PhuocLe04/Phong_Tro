using System;
using System.Collections.Generic;

namespace Phong_Tro.Models;

public partial class LoaiTaiKhoan
{
    public int LoaiTk { get; set; }

    public string? TenTk { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
