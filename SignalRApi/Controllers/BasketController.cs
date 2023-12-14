using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("BasketListByMenuTableWithProductName/{id}")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(x => x.MenuTableID == id).Select(x => new ResultBasketWithProduct
            {
                BasketID = x.BasketID,
                Count = x.Count,
                MenuTableID = x.MenuTableID,
                Price = x.Price,
                ProductID = x.ProductID,
                TotalPrice = x.TotalPrice,
                ProductName = x.Product.ProductName
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();

            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                Count = 1,
                MenuTableID = 4,
                Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(x => x.Price).FirstOrDefault(),
                TotalPrice = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(x => x.Price).FirstOrDefault(),
            });
            return Ok("Başarıyla eklendi.");
        }


    }
}
