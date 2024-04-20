using Microsoft.AspNetCore.Mvc;
using back.Services.Payments;
using back.Models;
using back.Services.Notifications;

namespace back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly ILogger<QuotesController> _logger;
        private IPaymentsServices _paymentsServices;
        private INotificationSender _notificationSender;

        public QuotesController(IPaymentsServices paymentsServices, INotificationSender notificationSender, ILogger<QuotesController> logger)
        {
            _logger = logger;
            _paymentsServices = paymentsServices;
            _notificationSender = notificationSender;
        }

        [HttpGet]
        public List<Quote> GetQuotes()
        {
            return new List<Quote>();
        }

        [HttpGet]
        public Quote GetQuote(int id)
        {
            return new Quote();
        }

        [HttpPost]
        public object PayQuote()
        {
            return new object();
        }
    }
}
