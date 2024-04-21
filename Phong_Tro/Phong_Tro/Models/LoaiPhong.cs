using System;
using System.Collections.Generic;

namespace Phong_Tro.Models;

public partial class LoaiPhong
{
    public int MaLoaiPhong { get; set; }

    public string TenLoaiPhong { get; set; } = null!;

    public virtual ICollection<PhongTro> PhongTros { get; set; } = new List<PhongTro>();
}
