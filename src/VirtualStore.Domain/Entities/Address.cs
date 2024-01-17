using System;
using VirtualStore.Core.DomainObjects;

namespace VirtualStore.Domain.Entities
{
	public class Address : Entity
	{
		protected Address() { }

        public Address(string street,
            string complement,
            string neighborhood,
            string postalCode,
            string city,
            string state)
        {
            Street = street;
            Complement = complement;
            Neighborhood = neighborhood;
            PostalCode = postalCode;
            City = city;
            State = state;
        }

        public string Street { get; private set; }
		public string Complement { get; private set; }
		public string Neighborhood { get; private set; }
		public string PostalCode { get; private set; }
		public string City { get; private set; }
		public string State { get; private set; }

        public void SetStreet(string value)
        {
            Street = value;
        }

        public void SetComplement(string value)
        {
            Complement = value;
        }

        public void SetNeighborhood(string value)
        {
            Neighborhood = value;
        }

        public void SetPostalCode(string value)
        {
            PostalCode = value;
        }

        public void SetCity(string value)
        {
            City = value;
        }

        public void SetState(string value)
        {
            State = value;
        }

    }
}

