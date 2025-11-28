using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lab1_TranNguyenDat.Models
{
    public partial class Chitietphieugiaohang
    {
        [StringLength(50), DisplayName("Mã phiếu giao hàng")]
        [Required(ErrorMessage = "Xin nhập mã phiếu giao hàng")]
        public string Mapgh { get; set; } = null!;
        [StringLength(50), DisplayName("Mã hàng")]
        [Required(ErrorMessage = "Xin nhập mã hàng")]
        public string Mahang { get; set; } = null!;
        [StringLength(50), DisplayName("Đơn vị tính")]
        [Required(ErrorMessage = "Xin nhập đơn vị tính")]
        public string? Donvitinh { get; set; }
        [StringLength(50), DisplayName("Số lượng")]
        [Required(ErrorMessage = "Xin nhập số lượng")]
        public double? Soluong { get; set; }

        public virtual Hanghoa MahangNavigation { get; set; } = null!;
        public virtual Phieugiaohang MapghNavigation { get; set; } = null!;
    }
}
