using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.domain.Entities
{
    public class Subscription
    {
        private IList<Payment> _payments;
        
        public Subscription(DateTime? expireDate)
        {
            Active = true;
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            _payments = new List<Payment>();
        }

        public bool Active { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

        public void AddPayment(Payment payment)
        {
            _payments.Add(payment);    
        }

        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        internal void Deactivate()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}