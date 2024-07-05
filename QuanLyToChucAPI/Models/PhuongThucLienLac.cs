using QuanLyToChuc.API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyToChucAPI.Models
{

    public class PhuongThucLienLac
    {
        public int PhuongThucLienLacID { get; set; }

        public int ToChucID { get; set; }
        public int LoaiLienLac { get; set; }
        public int LoaiNguoiLienLac { get; set; }
        public string SoDienThoai { get; set; }
        [ForeignKey("ToChucID")]
        public ToChuc? ToChuc { get; set; }
    }
}