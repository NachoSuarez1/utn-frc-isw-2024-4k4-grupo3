using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    [Table("Quotes")]
    public class Quote
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("pick_up_date")]
        public DateOnly PickUpDate { get; set; }
        [Column("delivery_date")]
        public DateOnly DeliveryDate { get; set; }
        [Column("amount")]
        public double Amount { get; set; }

        public User Transport { get; set; }
        public State State { get; set; }
        public PaymentOption? SelectedPaymentOption { get; set; }

        public List<PaymentOption> PaymentOptions { get; set; }

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

    [Table("States")]
    public class State
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }

    public class PaymentOption
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
