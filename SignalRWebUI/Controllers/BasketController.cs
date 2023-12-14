using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44330/api/Basket/BasketListByMenuTableWithProductName/{4}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketWithProduct>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket(int id)
        {
            CreateBasketDto createBasketDto = new CreateBasketDto();
            createBasketDto.ProductID = id;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44330/api/Basket", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return Json(createBasketDto);
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44330/api/Basket/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NoContent();
        }
    }
}
