using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTableController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;

		public MenuTableController(IMenuTableService menuTableService)
		{
			_menuTableService = menuTableService;
		}

		[HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			var value = _menuTableService.TMenuTableCount();
			return Ok(value);
		}


		[HttpGet]
		public IActionResult MenuTableList()
		{
			var values = _menuTableService.TGetListAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			_menuTableService.TAdd(new MenuTable()
			{
				Name= createMenuTableDto.Name,
				Status= false,
			});
			return Ok("Başarıyla eklendi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menuTableService.TGetByID(id);
			_menuTableService.TDelete(value);
			return Ok("Başarıyla silindi.");
		}

		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			_menuTableService.TUpdate(new MenuTable()
			{
				MenuTableID = updateMenuTableDto.MenuTableID,
				Name = updateMenuTableDto.Name,
				Status = updateMenuTableDto.Status,
			});
			return Ok("Başarıyla güncellendi.");
		}

		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetByID(id);
			return Ok(value);
		}

	}
}
