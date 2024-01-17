using System;
using VirtualStore.Core.DomainObjects;
using VirtualStore.Core.Enums;

namespace VirtualStore.Domain.Entities
{
	public class Product : Entity
	{
		protected Product() { }

        public Product(string name,
						string description,
						decimal price,
						string pictureUri,
						ProductType type,
						ProductBrand brand)
		{
			Name = name;
			Description = description;
			Price = price;
			PictureUri = pictureUri;
			Type = type;
			Brand = brand;
			BrandId = brand.Id;
		}

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public ProductType Type { get; private set; }
        public Guid BrandId { get; private set; } //Marca Id
        public ProductBrand Brand { get; private set; }//Objeto Marca

        public void SetName(string value)
		{
			Name = value;
		}

        public void SetDescription(string value)
        {
            Description = value;
        }

		public void SetPrice(decimal value)
		{
			Price = value;
		}

		public void SetPictureUri(string value)
		{
			PictureUri = value;
		}

		public void SetProductType(ProductType value)
		{
			Type = value;
		}

		public void SetBrand(ProductBrand value)
		{
			BrandId = value.Id;
			Brand = value;
		}
    }
}

