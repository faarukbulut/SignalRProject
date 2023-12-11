﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutController : ControllerBase
	{
		private readonly IAboutService _aboutService;
		private readonly IMapper _mapper;

		public AboutController(IAboutService aboutService, IMapper mapper)
		{
			_aboutService = aboutService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult AboutList()
		{
			var values = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateAbout(CreateAboutDto createAboutDto)
		{
			_aboutService.TAdd(new About()
			{
				Title = createAboutDto.Title,
				Description = createAboutDto.Description,
				ImageUrl = createAboutDto.ImageUrl,
			});
			return Ok("Başarıyla eklendi.");
		}

		[HttpDelete]
		public IActionResult DeleteAbout(int id)
		{
			var value = _aboutService.TGetByID(id);
			_aboutService.TDelete(value);
			return Ok("Başarıyla silindi.");
		}

		[HttpPut]
		public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
		{
			_aboutService.TUpdate(new About()
			{
				AboutID = updateAboutDto.AboutID,
				Title = updateAboutDto.Title,
				ImageUrl = updateAboutDto.ImageUrl,
				Description = updateAboutDto.Description,
			});
			return Ok("Başarıyla güncellendi.");
		}

		[HttpGet("GetAbout")]
		public IActionResult GetAbout(int id)
		{
			var value = _aboutService.TGetByID(id);
			return Ok(value);
		}
	}
}
