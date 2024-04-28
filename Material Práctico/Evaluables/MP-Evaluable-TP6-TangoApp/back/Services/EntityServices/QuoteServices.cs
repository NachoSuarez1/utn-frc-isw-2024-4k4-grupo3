using back.Data.Repositories.Abstractions;
using back.Data.Repositories.Implementations;
using back.Entities;
using back.Entities.DTOs;
using back.Migrations;
using back.Services.Payments;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace back.Services.EntityServices
{
    public class QuoteServices
    {
        IQuoteRepository _quoteRepository;
        IStateRepository _stateRepository;
        IPaymentOptionRepository _paymentOptionRepository;
        IPaymentServices _paymentServices;

        public QuoteServices(IQuoteRepository repository, IStateRepository stateRepository, IPaymentOptionRepository paymentOptionRepository, IPaymentServices paymentServices)
        {
            _quoteRepository = repository;
            _stateRepository = stateRepository;
            _paymentOptionRepository = paymentOptionRepository;
            _paymentServices = paymentServices;
        }

        public List<QuoteDTO> Get(int orderId, int? quoteId = null)
        {
            return quoteId is null
                ? _quoteRepository.Quotes.Where(q => q.OrderId == orderId).Select(QuoteDTO.ToDTO).ToList()
                : _quoteRepository.Quotes.Where(q => q.OrderId == orderId && q.Id == quoteId).Select(QuoteDTO.ToDTO).ToList();
        }

        public Quote ConfirmQuote(int orderId, int quoteId, PaymentRequest paymentRequest)
        {
            var orderQuotes = _quoteRepository.Quotes.Where(q => q.OrderId == orderId);
            if (!orderQuotes.Any() || !orderQuotes.Where(oq => oq.Id == quoteId).Any()) 
                throw new Exception("La cotización a confirmar no existe");

            var paymentType = _paymentServices.ProcessPayment(paymentRequest, _paymentOptionRepository);

            var confirmedState = _stateRepository.GetConfirmed();
            var discardedState = _stateRepository.GetDiscarded();

            foreach (var q in orderQuotes) {
                if (q.Id == quoteId) {
                    q.State = confirmedState;
                    q.SelectedPaymentOption = paymentType;
                }
                else
                    q.State = discardedState;

                _quoteRepository.Update(q);
            }

            return _quoteRepository.Quotes.Where(q => q.OrderId == orderId && q.Id == quoteId).First();
        }

        public void SetPending(int orderId)
        {
            var orderQuotes = _quoteRepository.Quotes.Where(q => q.OrderId == orderId);
            var pendingState = _stateRepository.GetPending();

            foreach (var q in orderQuotes) {
                q.State = pendingState;
                q.SelectedPaymentOption = null;
                _quoteRepository.Update(q);
            }
        }
    }
}
