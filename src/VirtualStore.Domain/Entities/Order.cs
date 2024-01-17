using System;
using VirtualStore.Core.DomainObjects;

namespace VirtualStore.Domain.Entities
{
	public class Order : Entity
	{
		public Order(decimal totalValue,
			decimal discount,
			Address address,
			Buyer buyer)
		{
			BuyerId = address.Id;
			AddressId = buyer.Id;
			TotalValue = totalValue;
			Discount = discount;
			Address = address;
			Buyer = buyer;
		}

		protected Order() { }

		public Guid BuyerId { get; private set; }
		public Guid AddressId { get; private set;}
		public decimal TotalValue { get; private set;}
		public decimal Discount { get; private set;}
		public Address Address { get; private set;}
		public Buyer Buyer { get; private set;}

		public List<OrderItem> Items { get; private set;}

		public void SetBuyer(Buyer buyer)
		{ 
			Buyer = buyer;
			BuyerId = buyer.Id;
		}
		public void SetAddress(Address address)
		{ 
			Address = address;
			AddressId = address.Id;
		}
		public void SetTotalValue(decimal value) 
		{
			TotalValue = value;
		}
		public void ApplyDiscount(decimal discount)
		{
			if ((TotalValue - discount) > 0)
			{
				TotalValue = TotalValue - discount;
			}
			else
			{ 
				TotalValue = 0;
			}
			Discount = discount;
		}











	}
}

