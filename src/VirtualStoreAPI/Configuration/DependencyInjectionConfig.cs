using System;
using MediatR;
using VirtualStore.Application.Interfaces;
using VirtualStore.Application.Services;
using VirtualStore.Core.UoW;
using VirtualStore.Domain.Interfaces;
using VirtualStore.Infra.Data.UoW;
using VirtualStory.Infra.Data.Context;
using VirtualStory.Infra.Data.Repositories;

namespace VirtualStore.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddMediatr();
            services.AddRepositories();
            services.AddServices();
        }

        public static void AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.Load("VirtualStore.Domain"));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<VirtualStoreDbContext>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IProductBrandRepository, ProductBrandRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IAddressAppService, AddressAppService>();
            services.AddScoped<IBasketItemAppService, BasketItemAppService>();
            services.AddScoped<IBasketAppService, BasketAppService>();
            services.AddScoped<IBuyerAppService, BuyerAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IOrderItemAppService, OrderItemAppService>();
            services.AddScoped<IPaymentMethodAppService, PaymentMethodAppService>();
            services.AddScoped<IProductBrandAppService, ProductBrandAppService>();
        }


    }
}