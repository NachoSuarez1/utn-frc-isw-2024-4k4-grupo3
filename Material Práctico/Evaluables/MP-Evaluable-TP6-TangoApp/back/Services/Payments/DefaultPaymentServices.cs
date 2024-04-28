using back.Data.Repositories.Abstractions;
using back.Entities;

namespace back.Services.Payments
{
    public class DefaultPaymentServices : IPaymentServices
    {
        private List<CardInfo> _cards;
        private List<string> _noFundsCardNumbers = new List<string>() { "5520000000000000", "5510000000000002" };

        public DefaultPaymentServices()
        {
            _cards =
            [
                // ● Probar pagar la cotización con tarjeta de crédito vigente y con saldo (pasa)
                // ● Probar pagar la cotización con tarjeta de crédito con datos no válido (falla)
                new CardInfo() { 
                    CardType = "Crédito",
                    CardNumber = "4200000000000000",
                    Pin = "123",
                    FullName = "SANTIAGO GUTIERREZ",
                    DocumentType = "DNI",
                    DocumentNumber = "43000000"
                },
                // ● Probar pagar la cotización con tarjeta de crédito sin saldo suficiente (falla)
                new CardInfo()
                {
                    CardType = "Crédito",
                    CardNumber = "5520000000000000",
                    Pin = "123",
                    FullName = "SANTIAGO GUTIERREZ",
                    DocumentType = "DNI",
                    DocumentNumber = "43000000"
                },
                // ● Probar pagar la cotización con tarjeta de débito vigente y con saldo (pasa)
                // ● Probar pagar la cotización con tarjeta de débito con datos no válido (falla)
                new CardInfo()
                {
                    CardType = "Débito",
                    CardNumber = "4000000000000002",
                    Pin = "987",
                    FullName = "SANTIAGO GUTIERREZ",
                    DocumentType = "DNI",
                    DocumentNumber = "43000000"
                },
                // ● Probar pagar la cotización con tarjeta de débito sin saldo suficiente (falla)
                new CardInfo()
                {
                    CardType = "Débito",
                    CardNumber = "5510000000000002",
                    Pin = "987",
                    FullName = "SANTIAGO GUTIERREZ",
                    DocumentType = "DNI",
                    DocumentNumber = "43000000"
                },
            ];
        }

        public PaymentOption ProcessPayment(PaymentRequest paymentRequest, IPaymentOptionRepository repository) 
        {
            var payment = repository.PaymentOptions.Where(po => po.Description == paymentRequest.PaymentOption).First();
            if (payment.IsCard()) {
                ValidateCard(paymentRequest.Card);
            }

            return payment;
        }

        void ValidateCard(CardInfo card)
        {
            var cardInfo = _cards.Where(c => c.CardNumber == card.CardNumber).FirstOrDefault();
            if (cardInfo == null)
                throw new Exception("El número de tarjeta ingresado no es válido");
            if (!cardInfo.Equals(card))
                throw new Exception("Alguno de los datos de la tarjeta es incorrecto... Revise e intente de nuevo");
            if (_noFundsCardNumbers.Contains(cardInfo.CardNumber))
                throw new Exception("La tarjeta ingresada no tiene fondos suficientes");
        }
    }
}
