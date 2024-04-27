using back.Models;
using back.Repositories.Abstractions;
using back.Services.Payments;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotesController : ControllerBase
    {
        IPaymentsServices _paymentsServices;
        IEmailSender _emailSender;
        QuotesService _quotesService;

        public QuotesController(IPaymentsServices paymentsServices, IEmailSender emailSender, QuotesService quotesService)
        {
            _paymentsServices = paymentsServices;
            _emailSender = emailSender;
            _quotesService = quotesService;
        }

        [HttpGet]
        public IActionResult Get(int orderId, int? quoteId) {
            try {
                var quotes = _quotesService.GetQuotes(orderId, quoteId);
                return Ok(quotes);
            }
            catch (Exception ex) {
                return NotFound(ex.Message);
            }
        } 

        [HttpPut]
        public IActionResult Confirm(int orderId, Quote quote, int selectedPaymentOption, PaymentInfo paymentInfo)
        {
            try {
                var payment = _quotesService.ConfirmQuote(orderId, quote, selectedPaymentOption, paymentInfo);
                return Ok(payment);
            }
            catch (PaymentException pe) {
                return BadRequest(pe.Message);
            }
            catch (Exception ex) {
                return NotFound(ex);
            }
        }
    }

    public class QuotesService
    {
        IQuoteRepository _quotesRepository;
        IStateRepository _stateRepository;
        IPaymentOptionRepository _paymentOptionRepository;
        IPaymentsServices _paymentsService;
        
        public QuotesService(IQuoteRepository quotesRepository, IStateRepository stateRepository, 
            IPaymentOptionRepository paymentOptionRepository, IPaymentsServices paymentsServices)
        {
            _quotesRepository = quotesRepository;
            _stateRepository = stateRepository;
            _paymentOptionRepository = paymentOptionRepository;
            _paymentsService = paymentsServices;
        }

        public List<Quote> GetQuotes(int orderId, int? quoteId = null)
        {
            var quotes = _quotesRepository.Quotes.Where(q => q.OrderId == orderId);
            if (!quotes.Any())
                throw new Exception("No hay cotizaciones para el Pedido seleccionado!");

            if (quoteId is not null) {
                quotes = quotes.Where(q => q.Id == quoteId).ToList();
                if (!quotes.Any()) 
                    throw new Exception("La cotización buscada no existe!");
            }

            return quotes.ToList();
        }

        public PaymentResult ConfirmQuote(int orderId, Quote quote, int selectedPaymentOption, PaymentInfo? paymentInfo = null)
        {
            var quotes = GetQuotes(orderId);
            if (!quotes.Any())
                throw new Exception("No hay cotizaciones para el Pedido seleccionado!");

            var confirmedQuote = quotes.Where(q => q.Id == quote.Id);
            if (confirmedQuote is null)
                throw new Exception("La cotización confirmada no existe!");

            var paymentOption = _paymentOptionRepository.GetPaymentOption(selectedPaymentOption);
            var payment = new PaymentResult();
            if (paymentOption.Description == "Tarjeta") {
                if (paymentInfo is null)
                    throw new PaymentException("Se seleccionó tarjeta, pero no hay información de Pago");
                payment = _paymentsService.ProcessPayment(paymentInfo);
            }

            var confirmed = _stateRepository.GetConfirmed();
            var discarded = _stateRepository.GetDiscarded();

            foreach (var q in quotes) {
                if (q.Id == quote.Id) {
                    q.State = confirmed;
                    q.SelectedPaymentOption = paymentOption;
                }
                else
                    q.State = discarded;

                _quotesRepository.Update(q);
            }

            return payment;
        }
    }
}
