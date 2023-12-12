using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ProductList()
		{
			var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
			return Ok(values);
		}

		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategory()
		{
			var context = new SignalRContext();
			var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDto
			{
				Description = y.Description,
				ImageUrl = y.ImageUrl,
				Price = y.Price,
				ProductID = y.ProductID,
				ProductName = y.ProductName,
				ProductStatus = y.ProductStatus,
				CategoryName = y.Category.CategoryName
			}).ToList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateProduct(CreateProductDto createProductDto)
		{
			_productService.TAdd(new Product()
			{
				Description= createProductDto.Description,
				ImageUrl= createProductDto.ImageUrl,
				Price= createProductDto.Price,
				ProductName= createProductDto.ProductName,
				ProductStatus = true,
				CategoryID = createProductDto.CategoryID
			});
			return Ok("Başarıyla eklendi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
		{
			var value = _productService.TGetByID(id);
			_productService.TDelete(value);
			return Ok("Başarıyla silindi.");
		}

		[HttpPut]
		public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
		{
			_productService.TUpdate(new Product()
			{
				ProductID = updateProductDto.ProductID,
				Description = updateProductDto.Description,
				ImageUrl = updateProductDto.ImageUrl,
				ProductStatus = updateProductDto.ProductStatus,
				ProductName= updateProductDto.ProductName,
				Price = updateProductDto.Price,
				CategoryID = updateProductDto.CategoryID
			});
			return Ok("Başarıyla güncellendi.");
		}

		[HttpGet("{id}")]
		public IActionResult GetProduct(int id)
		{
			var value = _productService.TGetByID(id);
			return Ok(value);
		}

		[HttpGet("ProductCount")]
		public IActionResult ProductCount()
		{
			var value = _productService.TProductCount();
			return Ok(value);
		}

		[HttpGet("ProductCountByCategoryNameHamburger")]
		public IActionResult ProductCountByCategoryNameHamburger()
		{
			var value = _productService.TProductCountByCategoryNameHamburger();
			return Ok(value);
		}

		[HttpGet("ProductCountByCategoryNameIcecek")]
		public IActionResult ProductCountByCategoryNameIcecek()
		{
			var value = _productService.TProductCountByCategoryNameIcecek();
			return Ok(value);
		}

		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{
			var value = _productService.TProductPriceAvg();
			return Ok(value);
		}

		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice()
		{
			var value = _productService.TProductNameByMaxPrice();
			return Ok(value);
		}

		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice()
		{
			var value = _productService.TProductNameByMinPrice();
			return Ok(value);
		}

		[HttpGet("ProductPriceAvgByHamburger")]
		public IActionResult ProductPriceAvgByHamburger()
		{
			var value = _productService.TProductPriceAvgByHamburger();
			return Ok(value);
		}
	}
}
