using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lab1_TranNguyenDat.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Phieugiaohangs = new HashSet<Phieugiaohang>();
        }
        [StringLength(50), DisplayName("Mã nhân viên")]
        [Required(ErrorMessage = "Xin nhập mã nhân viên")]
        public string Manv { get; set; } = null!;
        [StringLength(50), DisplayName("Tên nhân viên")]
        [Required(ErrorMessage = "Xin nhập tên nhân viên")]
        public string? Tennv { get; set; }
        [StringLength(50), DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Xin nhập ngày sinh")]
        public DateTime? Ngaysinh { get; set; }
        [StringLength(50), DisplayName("Phái")]
        [Required(ErrorMessage = "Xin nhập phái")]
        public bool? Phai { get; set; }
        [StringLength(50), DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Xin nhập địa chỉ")]
        public string? Diachi { get; set; }
        [MinLength(8), DisplayName("Password")]
        [Required(ErrorMessage = "Password không được để trống")]
        public string? Password { get; set; }

        public virtual ICollection<Phieugiaohang> Phieugiaohangs { get; set; }
    }
}
