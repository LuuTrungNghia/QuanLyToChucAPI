namespace QuanLyToChucAPI.DTOs
{
    public class AddressDto
    {
        public string TinhThanhPho { get; set; }
        public string QuanHuyen { get; set; }
        public string PhuongXa { get; set; }
        public string SoNhaDuongPho { get; set; }
    }

    public class CreateToChucRequest
    {
        public string TenToChuc { get; set; }
        public string MoTa { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public AddressDto Address { get; set; }
    }

    public class UpdateToChucRequest
    {
        public string TenToChuc { get; set; }
        public string MoTa { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public AddressDto Address { get; set; }
    }
}
