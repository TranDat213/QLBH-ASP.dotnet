using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab1_TranNguyenDat.Models
{
    public partial class Nhasanxuat
    {
        public Nhasanxuat()
        {
            Hanghoas = new HashSet<Hanghoa>();
        }
        [Key]
        [StringLength(50), DisplayName("Mã nhà sản xuất")]
        [Required(ErrorMessage = "Xin nhập mã nhà sản xuất")]
        public string Mansx { get; set; } = null!;

        [StringLength(50), DisplayName("Tên nhà sản xuất")]
        [Required(ErrorMessage = "Xin nhập tên nhà sản xuất")]
        public string? Tennsx { get; set; }
        [StringLength(50), DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Xin nhập địa chỉ")]
        public string? Diachi { get; set; }

        public virtual ICollection<Hanghoa> Hanghoas { get; set; }
    }
}
