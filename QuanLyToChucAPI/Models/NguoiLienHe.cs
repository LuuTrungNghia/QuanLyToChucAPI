using QuanLyToChuc.API.Models;
using System;

namespace QuanLyToChucAPI.Models
{
    public class NguoiLienHe
    {
        public int NguoiLienHeID { get; set; }
        public int ToChucID { get; set; }
        public string Ho { get; set; }
        public string TenDemVaTen { get; set; }
        public string ChucDanh { get; set; }
        public string LoaiLienHe { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public ToChuc ToChuc { get; set; }
    }
}
