using System;
using System.Collections.Generic;

namespace Phong_Tro.Models;

public partial class AnhPhongTro
{
    public int MaAnh { get; set; }

    public string MaPhongTro { get; set; } = null!;

    public string? Urlanh { get; set; }

    public virtual PhongTro MaPhongTroNavigation { get; set; } = null!;
}
