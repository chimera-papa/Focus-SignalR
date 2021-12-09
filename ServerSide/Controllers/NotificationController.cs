using System.Threading.Tasks;
using Common.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerSide.Service;

namespace ServerSide.Controllers
{
    public class NotificationController : Controller
    {
        private readonly NotificationService _notificationHub;

        public NotificationController(NotificationService notificationHub)
        {
            _notificationHub = notificationHub;
        }

        /// <summary>
        /// Send a global notification
        /// </summary>
        /// <param name="dto">request</param>
        /// <returns></returns>
        [HttpPost]
        [Route("notification/global")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GlobalNotification([FromBody] GlobalNotificationDto dto)
        {
            await _notificationHub.GlobalNotification(dto.Notification);
            return Ok();
        }
    }
}