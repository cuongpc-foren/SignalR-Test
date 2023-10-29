using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;
using SignalR.Models;
using SignalR.Tools;

namespace SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHubContext<SignalHub> _hubContext;

        public HomeController(IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        [Route("PushEmployee")]
        
        public IActionResult PushEmployee ( string Name, string Address, string Message)
        {
            Employee employee = new Employee();
            employee.Id = IdGenerator.GenerateId();
            employee.Name = Name;
            employee.Address = Address;
            employee.Message = Message;

            _hubContext.Clients.All.SendAsync("ReceiveEmployee", employee);
            return Ok("Done");
        }

        [HttpGet]
        [Route("PushMessage")]
        public IActionResult PushMessage(string Message)
        {
            _hubContext.Clients.All.SendAsync("RecieveMessage", Message);
            return Ok("Done");
        }
    }
}
