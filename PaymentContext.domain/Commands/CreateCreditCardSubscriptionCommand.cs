using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public Decimal Total { get; set; }
        public Decimal TotalPaid { get; set; }
        public Address Address { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string Payer { get; set; }
        public string PayerEmail { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome precisa ter no mínimo 3 caracteres")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome pode ter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome precisa ter no mínimo 3 caracteres")
                .HasMaxLen(LastName, 40, "Name.LastName", "Sobrenome pode ter no máximo 40 caracteres")
            );
        }
    }
}