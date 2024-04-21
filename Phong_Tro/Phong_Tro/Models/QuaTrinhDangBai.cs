using System;
using System.Collections.Generic;

namespace Phong_Tro.Models;

public partial class QuaTrinhDangBai
{
    public int MaQuaTrinhDangBai { get; set; }

    public string? MaBaiDang { get; set; }

    public string? Email { get; set; }

    public string? TrangThai { get; set; }

    public string? NoiDung { get; set; }

    public DateTime? NgayThayDoi { get; set; }

    public virtual TaiKhoan? EmailNavigation { get; set; }

    public virtual BaiDang? MaBaiDangNavigation { get; set; }
}
