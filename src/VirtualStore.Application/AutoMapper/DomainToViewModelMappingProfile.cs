using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Application.ViewModel;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ReverseMap();
            CreateMap<Address, AddressViewModel>()
               .ReverseMap();
            CreateMap<BasketItem, BasketItemViewModel>()
                .ReverseMap();
            CreateMap<Basket, BasketViewModel>()
                .ReverseMap();
            CreateMap<Buyer, BuyerViewModel>()
                .ReverseMap();
            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();
            CreateMap<Order, OrderViewModel>()
                .ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodViewModel>()
                .ReverseMap();
            CreateMap<ProductBrand, ProductBrandViewModel>()
                .ReverseMap();

        }
    }
}
