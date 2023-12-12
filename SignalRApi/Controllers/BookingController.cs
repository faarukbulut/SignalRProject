using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;
		private readonly IMapper _mapper;

		public BookingController(IBookingService bookingService, IMapper mapper)
		{
			_bookingService = bookingService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult BookingList()
		{
			var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateBooking(CreateBookingDto createBookingDto)
		{
			_bookingService.TAdd(new Booking()
			{
				Mail = createBookingDto.Mail,
				Date = createBookingDto.Date,
				Name = createBookingDto.Name,
				PersonCount = createBookingDto.PersonCount,
				Phone = createBookingDto.Phone,
			});
			return Ok("Başarıyla eklendi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBooking(int id)
		{
			var value = _bookingService.TGetByID(id);
			_bookingService.TDelete(value);
			return Ok("Başarıyla silindi.");
		}

		[HttpPut]
		public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
		{
			_bookingService.TUpdate(new Booking()
			{
				BookingID = updateBookingDto.BookingID,
				Mail = updateBookingDto.Mail,
				Date = updateBookingDto.Date,
				Name = updateBookingDto.Name,
				PersonCount = updateBookingDto.PersonCount,
				Phone = updateBookingDto.Phone,
			});
			return Ok("Başarıyla güncellendi.");
		}

		[HttpGet("{id}")]
		public IActionResult GetBooking(int id)
		{
			var value = _bookingService.TGetByID(id);
			return Ok(value);
		}
	}
}
