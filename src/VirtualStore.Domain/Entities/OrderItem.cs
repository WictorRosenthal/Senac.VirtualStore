using System;
using VirtualStore.Core.DomainObjects;

namespace VirtualStore.Domain.Entities
{
	public class OrderItem : Entity
	{
		public OrderItem(string productName,
			int amount,
			decimal unitValue,
			Order order,
			Product product)

		{
			OrderId = order.Id;
			ProductId = product.Id;
			ProductName = productName;
			Amount = amount;
			UnitValue = unitValue;
			Order = order;
			Product = product;
		}

		protected OrderItem () { }
		public Guid OrderId { get;  private set; }
		public Guid ProductId { get; private set;}
		public string ProductName { get; private set;}
		public int Amount { get; private set;}
		public decimal UnitValue { get; private set;}
		public Order Order { get; private set;}
		public Product Product { get; private set;}

		public void SetOrder(Order order)
		{ 
			OrderId = order.Id;
			Order = order;
		}
		public void SetProduct(Product product)
		{
			ProductId = product.Id;
			Product = product;
		}
        public void SetProductName(string value)
        {
            ProductName = value;
        }
        public void SetAmount(int value) 
		{
			Amount = value;
		}
		public void SetUnitValue(decimal value) 
		{
			UnitValue = value;
		}
		






	}
}

