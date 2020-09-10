using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>, 
    IHandler<CreatePayPalSubscriptionCommand>, IHandler<CreateCreditCardSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "não foi possível realizar seu cadastro");
            }

            //verificar se o documento já existe
            if (_repository.DocumentExists(command.Document))
            {
                AddNotifications(command);
                return new CommandResult(false, "já existe um cadastro com o documento informado");
            }

            //verificar se email já existe
            if (_repository.EmailExists(command.Email))
            {
                AddNotifications(command);
                return new CommandResult(false, "já existe um cadastro com o e-mail informado");
            }

            //gerar vo's
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            
            //gerar entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, address, 
            new Document(command.PayerDocument, command.PayerDocumentType), command.Payer, email);

            //relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //aplicar validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            //salvar informações
            _repository.CreateSubscription(student);

            //Enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "bem vindo ao serviceName", "Sua assinatura foi criada!");

            //retornar informações  
            return new CommandResult(true, "Assinatura realizada com sucesso!");
    }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "não foi possível realizar seu cadastro");
            }

            //verificar se o documento já existe
            if (_repository.DocumentExists(command.Document))
            {
                AddNotifications(command);
                return new CommandResult(false, "já existe um cadastro com o documento informado");
            }

            //verificar se email já existe
            if (_repository.EmailExists(command.Email))
            {
                AddNotifications(command);
                return new CommandResult(false, "já existe um cadastro com o e-mail informado");
            }

            //gerar vo's
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            
            //gerar entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(command.TransactionCode, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, address, 
            new Document(command.PayerDocument, command.PayerDocumentType), command.Payer, email);

            //relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //aplicar validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            //salvar informações
            _repository.CreateSubscription(student);

            //Enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "bem vindo ao serviceName", "Sua assinatura foi criada!");

            //retornar informações  
            return new CommandResult(true, "Assinatura realizada com sucesso!");
        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "não foi possível realizar seu cadastro");
            }

            //verificar se o documento já existe
            if (_repository.DocumentExists(command.Document))
            {
                AddNotifications(command);
                return new CommandResult(false, "já existe um cadastro com o documento informado");
            }

            //verificar se email já existe
            if (_repository.EmailExists(command.Email))
            {
                AddNotifications(command);
                return new CommandResult(false, "já existe um cadastro com o e-mail informado");
            }

            //gerar vo's
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            
            //gerar entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(command.CardHolderName, command.CardNumber, command.LastTransactionNumber, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, address, 
            new Document(command.PayerDocument, command.PayerDocumentType), command.Payer, email);

            //relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //aplicar validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            //salvar informações
            _repository.CreateSubscription(student);

            //Enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "bem vindo ao serviceName", "Sua assinatura foi criada!");

            //retornar informações  
            return new CommandResult(true, "Assinatura realizada com sucesso!");
        }
    }
}