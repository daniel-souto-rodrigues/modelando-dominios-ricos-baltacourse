namespace PaymentContext.Domain.ValueObjects
{
    public class Email
    {
        public string Address { get; set; }

        public Email(string address)
        {
            Address = address;
        }
    }
}