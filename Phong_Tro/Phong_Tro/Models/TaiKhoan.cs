using System;
using System.Collections.Generic;

namespace Phong_Tro.Models;

public partial class TaiKhoan
{
    public string Email { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public int LoaiTk { get; set; }

    public virtual ICollection<ChuTro> ChuTros { get; set; } = new List<ChuTro>();

    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();

    public virtual LoaiTaiKhoan LoaiTkNavigation { get; set; } = null!;

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();

    public virtual ICollection<QuaTrinhDangBai> QuaTrinhDangBais { get; set; } = new List<QuaTrinhDangBai>();

    public virtual ICollection<QuanLy> QuanLies { get; set; } = new List<QuanLy>();
}
