using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Aplication.Intefaces;
using VirtualStore.Aplication.ViewMode1;
using VirtualStore.Core.UoW;
using VirtualStore.Domain.Entities;
using VirtualStore.Domain.Interfaces;
using VirtualStore.Infra.Data.UoW;

namespace VirtualStore.Aplication.Services
{
    public class ProductAppServices : BaseServices, IProductAppService
    {
        protected readonly IProductRepository _repository;
        protected readonly IMapper _mapper;

        public ProductAppServices(IProductRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediator bus) : base(unitOfWork, bus)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ProductViewModel Add(ProductViewModel entity)
        {
            Product domain = _mapper.Map<Product>(entity);
            domain = _repository.Add(domain);
            Commit();

            ProductViewModel viewModel = _mapper.Map<ProductViewModel>(entity);
            return viewModel;
        }

    

        public ProductViewModel GetById(Guid Id)
        {
            var domain = _repository.GetById(Id);
            var viewModel = _mapper.Map<ProductViewModel>(domain);
            return viewModel;
        }

        public void Remove(Guid Id)
        {
            _repository.Remove(Id);
            Commit();
        }

        public void Remove(Expression<Func<Product, bool>> predicate)
        {
            _repository.Remove(predicate);
            Commit();
        }

        public IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> predicate)
        {
            IEnumerable<Product> domais = _repository.Search(predicate);
            IEnumerable<ProductViewModel> viewModels = _mapper.Map<IEnumerable<ProductViewModel>>(domais);
            return viewModels;
        }

        public IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> predicate, int PageNumber, int PageSize)
        {
            var domains = _repository.Search(predicate, PageNumber, PageSize);
            var viewModels = _mapper.Map<IEnumerable<ProductViewModel>>(domains);
            return viewModels;
        }

        public ProductViewModel Update(ProductViewModel entity)
        {
            var domain = _mapper.Map<Product>(entity);
            domain = _repository.Update(domain);
            Commit();

            ProductViewModel viewModel = _mapper.Map<ProductViewModel>(domain);
            return viewModel;
        }
    }
}
