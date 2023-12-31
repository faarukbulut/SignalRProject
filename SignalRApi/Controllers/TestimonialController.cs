﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;
		private readonly IMapper _mapper;

		public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
		{
			_testimonialService = testimonialService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult TestimonialList()
		{
			var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
		{
			_testimonialService.TAdd(new Testimonial()
			{
				Title = createTestimonialDto.Title,
				Comment = createTestimonialDto.Comment,
				ImageUrl = createTestimonialDto.ImageUrl,
				Name = createTestimonialDto.Name,
				Status = true,
			});
			return Ok("Başarıyla eklendi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteTestimonial(int id)
		{
			var value = _testimonialService.TGetByID(id);
			_testimonialService.TDelete(value);
			return Ok("Başarıyla silindi.");
		}

		[HttpPut]
		public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
		{
			_testimonialService.TUpdate(new Testimonial()
			{
				TestimonialID = updateTestimonialDto.TestimonialID,
				Title = updateTestimonialDto.Title,
				Comment = updateTestimonialDto.Comment,
				ImageUrl = updateTestimonialDto.ImageUrl,
				Name = updateTestimonialDto.Name,
				Status = updateTestimonialDto.Status,
			});
			return Ok("Başarıyla güncellendi.");
		}

		[HttpGet("{id}")]
		public IActionResult GetTestimonial(int id)
		{
			var value = _testimonialService.TGetByID(id);
			return Ok(value);
		}

	}
}
