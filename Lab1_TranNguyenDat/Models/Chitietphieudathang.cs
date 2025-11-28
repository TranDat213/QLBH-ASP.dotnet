using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lab1_TranNguyenDat.Models
{
    public partial class Chitietphieudathang
    {
        [StringLength(50), DisplayName("Mã phiếu đặt hàng")]
        [Required(ErrorMessage = "Xin nhập mã phiếu đặt hàng")]
        public string Mapdh { get; set; } = null!;
        [StringLength(50), DisplayName("Mã hàng")]
        [Required(ErrorMessage = "Xin nhập mã hàng")]
        public string Mahang { get; set; } = null!;
        [StringLength(50), DisplayName("Mã đơn giá")]
        [Required(ErrorMessage = "Xin nhập đơn giá")]
        public double? Dongia { get; set; }
        [StringLength(50), DisplayName("Số lượng")]
        [Required(ErrorMessage = "Xin nhập số lượng")]
        public double? Soluong { get; set; }

        public virtual Hanghoa MahangNavigation { get; set; } = null!;
        public virtual Phieudathang MapdhNavigation { get; set; } = null!;
    }
}
