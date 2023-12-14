using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}

		[HttpGet]
		public IActionResult NotificationList()
		{
			var values = _notificationService.TGetListAll();
			return Ok(values);
		}

		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			var values = _notificationService.TNotificationCountByStatusFalse();
			return Ok(values);
		}

		[HttpGet("GetAllNotificationByFalse")]
		public IActionResult GetAllNotificationByFalse()
		{
			var values = _notificationService.TGetAllNotificationByFalse();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{
			_notificationService.TAdd(new Notification()
			{
				Description= createNotificationDto.Description,
				Icon= createNotificationDto.Icon,
				Date= createNotificationDto.Date,
				Status = false,
				Type= createNotificationDto.Type,
			});
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetByID(id);
			_notificationService.TDelete(value);
			return Ok("Başarıyla silindi.");
		}

		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TGetByID(id);
			return Ok(value);
		}


		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			_notificationService.TUpdate(new Notification()
			{
				NotificationID = updateNotificationDto.NotificationID
				Description = updateNotificationDto.Description,
				Icon = updateNotificationDto.Icon,
				Date = updateNotificationDto.Date,
				Status = updateNotificationDto.Status,
				Type = updateNotificationDto.Type,
			});
		}
	}
}
