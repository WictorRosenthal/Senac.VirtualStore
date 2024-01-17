using System;
using VirtualStore.Core.DomainObjects;

namespace VirtualStore.Domain.Entities
{
	public class ProductBrand : Entity
	{
		public string BrandName { get; private set; }

		protected ProductBrand() { }

		public ProductBrand(string brandName)
		{
			BrandName = brandName;
		}

		public void SetBrandName(string value)
		{
			BrandName = value;
		}
	}
}

