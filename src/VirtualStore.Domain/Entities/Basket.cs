using System;
using VirtualStore.Core.DomainObjects;

namespace VirtualStore.Domain.Entities
{
	public class Basket : Entity
	{
		protected Basket()
		{
		}

		public Basket(Buyer buyer)
		{
			Buyer = buyer;

			Items = new List<BasketItem>();
        }

		public Guid BuyerId { get; private set; }
		public Buyer Buyer { get; private set; }

		public List<BasketItem> Items { get; set; }

		public void SetBuyer(Buyer buyer)
		{
			Buyer = buyer;
			BuyerId = buyer.Id;
        }

		public void AddItem(BasketItem item)
		{
			Items.Add(item);
		}

	}
}

