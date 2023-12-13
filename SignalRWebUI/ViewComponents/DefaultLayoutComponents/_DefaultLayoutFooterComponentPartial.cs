using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDto;
using SignalRWebUI.Dtos.SocialMediaDto;

namespace SignalRWebUI.ViewComponents.DefaultLayoutComponents
{
    public class _DefaultLayoutFooterComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultLayoutFooterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44330/api/Contact");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData1);

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44330/api/SocialMedia");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData2);

            ViewBag.Location = values1.Select(x => x.Location).FirstOrDefault();
            ViewBag.Phone = values1.Select(x => x.Phone).FirstOrDefault();
            ViewBag.Mail = values1.Select(x => x.Mail).FirstOrDefault();
            ViewBag.FooterDescription = values1.Select(x => x.FooterDescription).FirstOrDefault();
            
            return View(values2);
        }
    }
}
