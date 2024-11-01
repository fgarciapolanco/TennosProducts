using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Security.AccessControl;
using System.Text;
using TennosProducts.Client.Models;
using TennosProducts.Core.Dto;
using TennosProducts.Core.Entities;

namespace TennosProducts.Client.Controllers
{
    public class ProductoController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductoController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5170/api");
        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/TodosLosProductos");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var productos = JsonConvert.DeserializeObject<IEnumerable<ProductoViewModel>>(content);
                return View("Index", productos);
            }
            return View(new List<ProductoViewModel>());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoDto producto)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(producto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/AgregarProducto", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear producto");
                }
            }
            return View(producto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var resonse = await _httpClient.GetAsync($"/BuscarProductoPorID?ProductoID={id}");

            if (resonse.IsSuccessStatusCode)
            {
                var content = await resonse.Content.ReadAsStringAsync();
                var producto = JsonConvert.DeserializeObject<ProductoViewModel>(content);

                return View(producto);
            }

            else
            {
                return RedirectToAction("Details");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductoDto productoDto)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(productoDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"/AtualizarProducto?id={id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", new { id });
                }
                else
                {

                    ModelState.AddModelError(String.Empty, "Error al actualizar");
                }


            }
            return View(productoDto);
        }
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"/BuscarProductoPorID?ProductoID={id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var producto = JsonConvert.DeserializeObject<ProductoViewModel>(content);
                return View(producto);

            }
            else
            {
                return RedirectToAction("Details");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/BorrarProducto/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
           
                
                TempData["Error"] = "Error al eleiminar producto";
                return RedirectToAction("Index");

            }
        }
    }
}
