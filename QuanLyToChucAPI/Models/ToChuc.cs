using QuanLyToChucAPI.Models;
using System.Collections.Generic;

namespace QuanLyToChuc.API.Models
{
    public class ToChuc
    {
        public int Id { get; set; }
        public string TenToChuc { get; set; }
        public string MoTa { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }

        public ICollection<NguoiLienHe>? NguoiLienHes { get; set; }
        public ICollection<PhuongThucLienLac>? PhuongThucLienLacs { get; set; }

        public ICollection<ThongTinDinhDanh>? ThongTinDinhDanhs { get; set; }

    }
}