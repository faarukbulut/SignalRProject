using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SliderController : ControllerBase
	{
		private readonly ISliderService _SliderService;
		private readonly IMapper _mapper;

		public SliderController(ISliderService SliderService, IMapper mapper)
		{
			_SliderService = SliderService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SliderList()
		{
			var values = _mapper.Map<List<ResultSliderDto>>(_SliderService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateSlider(CreateSliderDto createSliderDto)
		{
			_SliderService.TAdd(new Slider()
			{
				Description1= createSliderDto.Description1,
				Description2= createSliderDto.Description2,
				Description3= createSliderDto.Description3,
				Title1= createSliderDto.Title1,
				Title2= createSliderDto.Title2,
				Title3= createSliderDto.Title3,
			});
			return Ok("Başarıyla eklendi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteSlider(int id)
		{
			var value = _SliderService.TGetByID(id);
			_SliderService.TDelete(value);
			return Ok("Başarıyla silindi.");
		}

		[HttpPut]
		public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
		{
			_SliderService.TUpdate(new Slider()
			{
				SliderID = updateSliderDto.SliderID,
				Description1 = updateSliderDto.Description1,
				Description2 = updateSliderDto.Description2,
				Description3 = updateSliderDto.Description3,
				Title1 = updateSliderDto.Title1,
				Title2 = updateSliderDto.Title2,
				Title3 = updateSliderDto.Title3,
			});
			return Ok("Başarıyla güncellendi.");
		}

		[HttpGet("{id}")]
		public IActionResult GetSlider(int id)
		{
			var value = _SliderService.TGetByID(id);
			return Ok(value);
		}

	}
}
