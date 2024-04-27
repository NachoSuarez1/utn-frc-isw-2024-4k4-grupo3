namespace back.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public User User { get; set; }
        public User Transport { get; set; }
        public DateOnly PickUpDate { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public double Amount { get; set; }
        public State State { get; set; }
        public List<PaymentOption> PaymentOptions { get; set; }
        public PaymentOption? SelectedPaymentOption { get; set; }

        #region Constructors
        public Quote()
        {
            State = State.Pendiente;
            SelectedPaymentOption = null;
        }

        public Quote(int id, User user, User transport, DateOnly pickUpDate, DateOnly deliveryDate, double amount, State state, 
            List<PaymentOption> paymentOptions, PaymentOption? selectedPaymentOption)
        {
            Id = id;
            User = user;
            Transport = transport;
            PickUpDate = pickUpDate;
            DeliveryDate = deliveryDate;
            Amount = amount;
            State = state;
            PaymentOptions = paymentOptions;
            SelectedPaymentOption = selectedPaymentOption;
        }
        #endregion

        #region States
        public void Confirm(PaymentOption option)
        {
            State = State.Confirmado;
            SelectedPaymentOption = option;
        }
        
        public void Discard() => State = State.Descartado;
        #endregion
    }

    public enum State
    {
        Confirmado,
        Descartado,
        Pendiente
    }

    public enum PaymentOption
    {
        Tarjeta,
        ContadoRetirar,
        ContadoEntrega
    }
}
