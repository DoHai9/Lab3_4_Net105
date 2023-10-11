using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class SanPhamController : Controller
    {
        public SanPhamController()
        {
            
        }
        // GET: SanPhamController
        public async Task<ActionResult> Index1()
        {
            string requestURL = "https://localhost:7176/api/SanPham/get-all";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(requestURL);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var sanphams = JsonConvert.DeserializeObject<List<SanPham>>(apiData);
            return View(sanphams);
        }

        // GET: SanPhamController/Details/5
        public async Task<ActionResult> Details(string MaSP)
        {
            string requestURL = $"https://localhost:7176/api/SanPham/get-by-masp?MaSP={MaSP}";
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(requestURL);
            string apiData = await reponse.Content.ReadAsStringAsync();
            var sanphams = JsonConvert.DeserializeObject<SanPham>(apiData);
            return View(sanphams);
        }

        // GET: SanPhamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPhamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SanPham sp)
        {
            string requestURL = $"https://localhost:7176/api/SanPham/post-by-masp";
            var httpsClient = new HttpClient();
            var obj = JsonConvert.SerializeObject(sp);
            var reponse = await httpsClient.PostAsJsonAsync(requestURL, sp);
            if (reponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index1");
            }
            else return BadRequest(reponse);
        }

        // GET: SanPhamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SanPhamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string MaSP, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SanPhamController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(string MaSP)
        {
            string requestURL = $"https://localhost:7176/api/SanPham/{MaSP}";
            var httpsClient = new HttpClient();
            var reponse = await httpsClient.GetAsync(requestURL);
            string apiData = await httpsClient.GetStringAsync(requestURL);
            if (reponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index1");
            }else return BadRequest(reponse);
            
        }

        // POST: SanPhamController/Delete/5
        



    }
}
