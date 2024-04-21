using System;
using System.Collections.Generic;

namespace Phong_Tro.Models;

public partial class BaiDang
{
    public string MaBaiDang { get; set; } = null!;

    public string MaChuTro { get; set; } = null!;

    public string MaPhongTro { get; set; } = null!;

    public int GiaPhong { get; set; }

    public string? NoiDung { get; set; }

    public DateTime NgayDang { get; set; }

    public virtual ICollection<DanhGia> DanhGia { get; set; } = new List<DanhGia>();

    public virtual ChuTro MaChuTroNavigation { get; set; } = null!;

    public virtual PhongTro MaPhongTroNavigation { get; set; } = null!;

    public virtual ICollection<QuaTrinhDangBai> QuaTrinhDangBais { get; set; } = new List<QuaTrinhDangBai>();
}
