using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab3_4_C_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        public SanPhamDbContext Context = new SanPhamDbContext();
        // GET: api/<SanPhamController>
        [HttpGet("get-all")]
        public IEnumerable<SanPham> GetAll()
        {
            return Context.sanPhams.ToList();
        }

        // GET api/<SanPhamController>/5
        [HttpGet("get-by-masp")]
        public SanPham GetByMaSP(string MaSP)
        {
            return Context.sanPhams.Find(MaSP);
        }

        // POST api/<SanPhamController>
        [HttpPost("post-by-masp")]
        public bool PostByMaSP(string Masp, string tenSanPham, int gia, int soluongkho, string nhaxuatban, string thuonghieu)
        {
            SanPham sanPham = new SanPham
            {
                MaSP = Masp,
                TenSP = tenSanPham,
                Gia = gia,
                SLTon = soluongkho,
                NSX = nhaxuatban,
                ThuongHieu = thuonghieu,
            };
            try
            {
                Context.sanPhams.Add(sanPham);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // PUT api/<SanPhamController>/5
        [HttpPut("put-by-masp")]
        public bool PutByMaSP(string MaSP, [FromBody] SanPham sanPham)
        {
            
            SanPham sp = Context.sanPhams.FirstOrDefault(p => p.MaSP == MaSP);
            try
            {
                sp.TenSP = sanPham.TenSP;
                sp.Gia = sanPham.Gia;
                sp.SLTon = sanPham.SLTon;
                sp.NSX = sanPham.NSX;
                sp.ThuongHieu = sanPham.ThuongHieu;
                Context.sanPhams.Update(sp);
                Context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        // DELETE api/<SanPhamController>/5
        [HttpDelete("{masp}")]
        public bool Delete(string MaSP)
        {
            try
            {
                SanPham sp = Context.sanPhams.Find(MaSP);
                Context.sanPhams.Remove(sp);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpGet]
        [Route("tinh tien")]
        public int TinhTien(double price, double coupon, double voucher)
        {
            var a = price * (1 - coupon / 100) - voucher;
            return (int)a;
        }
    }
}
