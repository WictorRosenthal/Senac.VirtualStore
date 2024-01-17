using System;
using VirtualStore.Core.DomainObjects;

namespace VirtualStore.Domain.Entities
{
	public class BasketItem : Entity
	{
		protected BasketItem()
		{
		}

        public BasketItem(decimal unitPrice,
			int quantity,
			Product product,
			Guid basketId)
        {
            UnitPrice = unitPrice;
            Quantity = quantity;
            Product = product;
            ProductId = product.Id;
			BasketId = basketId;
        }

		public Guid BasketId { get; private set; }

		public Basket Basket { get; private set; }
        public decimal UnitPrice { get; private set; }
		public int Quantity { get; private set; }
		public Product Product { get; private set; }
		public Guid ProductId { get; private set; }

		public void SetUnitPrice(decimal value)
		{
			UnitPrice = value;
		}

		public void SetQuantity(int value)
		{
			Quantity = value;
		}

		public void SetProduct(Product product)
		{
			Product = product;
			ProductId = product.Id;
		}
	}

}

