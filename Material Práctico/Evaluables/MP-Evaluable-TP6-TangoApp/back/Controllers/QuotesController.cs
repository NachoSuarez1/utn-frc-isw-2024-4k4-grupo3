using back.Models;
using back.Services.Payments;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly ILogger<QuotesController> _logger;
        private IPaymentsServices _paymentsServices;
        private IEmailSender _emailSender;

        public QuotesController(IPaymentsServices paymentsServices, IEmailSender emailSender, ILogger<QuotesController> logger)
        {
            _logger = logger;
            _paymentsServices = paymentsServices;
            _emailSender = emailSender;
        }

        [HttpGet]
        public List<Quote> Get(int orderId, int? quoteId)
        {
            var quotes = new List<Quote>();
            return quotes;
        }

        [HttpPost]
        public object Confirm()
        {
            return new object();
        }
    }
}
