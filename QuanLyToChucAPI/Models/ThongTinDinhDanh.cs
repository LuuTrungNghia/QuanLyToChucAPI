using QuanLyToChuc.API.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyToChucAPI.Models
{
    public class ThongTinDinhDanh
    {
        public int ThongTinDinhDanhID { get; set; }
        public int ToChucID { get; set; }
        public string MaSoThue { get; set; }
        public string NoiCap { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        [ForeignKey("ToChucID")]
        public ToChuc? ToChuc { get; set; }
    }
}
