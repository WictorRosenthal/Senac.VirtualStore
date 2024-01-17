using System;
using VirtualStore.Core.DomainObjects;

namespace VirtualStore.Domain.Entities
{
	public class Buyer : Entity
	{
		protected Buyer() { }

		public Buyer(
			string name,
			string surname,
			string email,
			Guid addressId,
			Address principalAddress,
			string phone,
			string document,
			string gender,
			List<PaymentMethod> paymentMethod
			)
		{
			Name = name;
			Surname = surname;
			Email = email;
			AddressId = addressId;
			PrincipalAddress = principalAddress;
			Phone = phone;
			Document = document;
			Gender = gender;
			paymentMethod = paymentMethod;
		}

		public string Name { get; private set; }
		public string Surname { get; private set; }
		public string Email { get; private set; }
		public Guid AddressId { get; private set; }
		public Address PrincipalAddress { get; private set; }
		public string Phone { get; private set; }
		public string Document { get; private set; }
		public string Gender { get; private set; }

		public List<PaymentMethod> PaymentMethods { get; private set; }
	}
}

