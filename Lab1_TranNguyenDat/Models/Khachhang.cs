using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lab1_TranNguyenDat.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Phieudathangs = new HashSet<Phieudathang>();
        }

        [StringLength(50), DisplayName("Mã khách hàng")]
        [Required(ErrorMessage = "Xin nhập mã khách hàng")]
        public string Makh { get; set; } = null!;
        [StringLength(50), DisplayName("Tên khách hàng")]
        [Required(ErrorMessage = "Xin nhập tên khách hàng")]
        public string? Tenkh { get; set; }
        [DisplayName("Năm sinh")]
        [Required(ErrorMessage = "Xin nhập Năm sinh")]
        public int? Namsinh { get; set; }
        [DisplayName("Phái")]
        public bool? Phai { get; set; }
        [Phone(ErrorMessage="Số điện thoại không hợp lệ") ]
        [DisplayName("Điện thoại")]
        [Required(ErrorMessage = "Xin nhập số điện thoại")]
        public string? Dienthoai { get; set; }
        [StringLength(50), DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Xin nhập địa chỉ")]
        public string? Diachi { get; set; }
        [MinLength(8, ErrorMessage ="Mật khẩu phải hơn 8 ký tự")]
         [DisplayName("Password")]
        [Required(ErrorMessage = "Password không được để trống")]
        public string? Password { get; set; }

        public virtual ICollection<Phieudathang> Phieudathangs { get; set; }
    }
}
