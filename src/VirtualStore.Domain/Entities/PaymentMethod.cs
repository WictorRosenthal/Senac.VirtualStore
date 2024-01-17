using System;
using VirtualStore.Core.DomainObjects;

namespace VirtualStore.Domain.Entities
{
	public class PaymentMethod : Entity
    {
        public PaymentMethod(string cardBrand, Guid cardId, string last4, Buyer buyer)
        {
            CardBrand = cardBrand;
            CardId = cardId;
            Last4 = last4;
            Buyer = buyer;
            BuyerId = buyer.Id;
        }

        protected PaymentMethod()
		{
		}

		public string CardBrand { get; private set; } //Bandeira do cartão
		public Guid CardId { get; private set; } //O verdadeiro número do cartão fica num sistema externo, então temos apenas aqui um ID que liga no sistema do cartão.
		public string Last4 { get; private set; }

        public Guid BuyerId { get; private set; }
        public Buyer Buyer { get; private set; }

        public void SetBuyer(Buyer buyer)
        { 
            BuyerId = buyer.Id;
            Buyer = buyer;
        }

        public void SetCardBrand(string value)
        {
            CardBrand = value;
        }

        public void SetCardId(Guid value)
        {
            CardId = value;
        }

        public void SetLast4(string value)
        {
            Last4 = value;
        }
    }
}

