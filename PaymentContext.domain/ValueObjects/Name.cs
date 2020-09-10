using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(firstName, 3, "Name.FirstName", "Nome precisa ter no mínimo 3 caracteres")
                .HasMaxLen(firstName, 40, "Name.FirstName", "Nome pode ter no máximo 40 caracteres")
                .HasMinLen(lastName, 3, "Name.LastName", "Sobrenome precisa ter no mínimo 3 caracteres")
                .HasMaxLen(lastName, 40, "Name.LastName", "Sobrenome pode ter no máximo 40 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}