using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab1_TranNguyenDat.Models
{
    public partial class Hanghoa
    {
        public Hanghoa()
        {
            Chitietphieudathangs = new HashSet<Chitietphieudathang>();
            Chitietphieugiaohangs = new HashSet<Chitietphieugiaohang>();
        }
        [Key]
        [StringLength(50), DisplayName("Mã hàng hóa")]
        [Required(ErrorMessage ="Xin nhập mã hàng hóa")]
        public string Mahang { get; set; } = null!;
        [StringLength(50), DisplayName("Tên hàng hóa")]
        [Required(ErrorMessage = "Xin nhập tên hàng hóa")]
        public string? Tenhang { get; set; }
        [StringLength(50), DisplayName("Đơn vị tính")]
        [Required(ErrorMessage = "Xin nhập đơn vị tính")]
        public string? Donvitinh { get; set; }

        [DisplayName("Đơn giá")]
        [Required(ErrorMessage = "Xin nhập đơn giá")]
        public double? Dongia { get; set; }

        [StringLength(500), DisplayName("Hình ảnh")]
        public string? Hinh { get; set; }
        [StringLength(50), DisplayName("Mã loại hàng")]
        public string? Maloai { get; set; }
        [StringLength(50), DisplayName("Mã nhà sản xuất")]
        public string? Mansx { get; set; }

        public virtual Loaihanghoa? MaloaiNavigation { get; set; }
        public virtual Nhasanxuat? MansxNavigation { get; set; }
        public virtual ICollection<Chitietphieudathang> Chitietphieudathangs { get; set; }
        public virtual ICollection<Chitietphieugiaohang> Chitietphieugiaohangs { get; set; }
    }
}
