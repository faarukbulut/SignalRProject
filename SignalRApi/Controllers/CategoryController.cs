using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryService caategoryService, IMapper mapper)
		{
			_categoryService = caategoryService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult CategoryList()
		{
			var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
		{
			_categoryService.TAdd(new Category()
			{
				CategoryName = createCategoryDto.CategoryName,
				Status = true,
			});
			return Ok("Başarıyla eklendi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCategory(int id)
		{
			var value = _categoryService.TGetByID(id);
			_categoryService.TDelete(value);
			return Ok("Başarıyla silindi.");
		}

		[HttpPut]
		public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			_categoryService.TUpdate(new Category()
			{
				CategoryID = updateCategoryDto.CategoryID,
				CategoryName = updateCategoryDto.CategoryName,
				Status = updateCategoryDto.Status,
			});
			return Ok("Başarıyla güncellendi.");
		}

		[HttpGet("{id}")]
		public IActionResult GetCategory(int id)
		{
			var value = _categoryService.TGetByID(id);
			return Ok(value);
		}
	}
}
