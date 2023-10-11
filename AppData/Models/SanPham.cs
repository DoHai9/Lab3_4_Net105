using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class SanPham
    {
        [Key]
        [Required(ErrorMessage ="Mã không được quá 4 ký tự ")]
        [MaxLength(4)]
        public string MaSP { get; set; }
        [Required(ErrorMessage ="Tên chỉ có độ dài dưới 14 ký tự")]
        [MaxLength(15)]
        public string TenSP { get; set; }
        [Range(1000, 30000000, ErrorMessage = "Giá phải từ 1000 đến 30.000.000")]
        public int Gia { get; set; }
        public int SLTon { get; set; }
        public string NSX { get; set; }
        public string ThuongHieu { get; set; }
    }
}
