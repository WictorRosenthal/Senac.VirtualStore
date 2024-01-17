using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Application.Interfaces;
using VirtualStore.Application.ViewModel;
using VirtualStore.Core.UoW;
using VirtualStore.Domain.Entities;
using VirtualStore.Domain.Interfaces;

namespace VirtualStore.Application.Services
{
    public class ProductBrandAppService : BaseService, IProductBrandAppService
    {
        protected IProductBrandRepository _repository;
        protected IMapper _mapper;

        public ProductBrandAppService(IProductBrandRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediator bus) : base(unitOfWork, bus)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ProductBrandViewModel Add(ProductBrandViewModel entity)
        {
            ProductBrand domain = _mapper.Map<ProductBrand>(entity);
            domain = _repository.Add(domain);
            Commit();

            ProductBrandViewModel viewModel = _mapper.Map<ProductBrandViewModel>(domain);
            return viewModel;
        }

        public ProductBrandViewModel GetById(Guid Id)
        {
            var domain = _repository.GetById(Id);
            var viewModel = _mapper.Map<ProductBrandViewModel>(domain);
            return viewModel;
        }

        public void Remove(Guid Id)
        {
            _repository.Remove(Id);
            Commit();
        }

        public void Remove(Expression<Func<ProductBrand, bool>> predicate)
        {
            _repository.Remove(predicate);
            Commit();
        }

        public IEnumerable<ProductBrandViewModel> Search(Expression<Func<ProductBrand, bool>> predicate)
        {
            IEnumerable<ProductBrand> domains = _repository.Search(predicate);
            IEnumerable<ProductBrandViewModel> viewModels = _mapper.Map<IEnumerable<ProductBrandViewModel>>(domains);
            return viewModels;
        }

        public IEnumerable<ProductBrandViewModel> Search(Expression<Func<ProductBrand, bool>> predicate,
            int pageNumber, int pageSize)
        {
            var domains = _repository.Search(predicate, pageNumber, pageSize);
            var viewModels = _mapper.Map<IEnumerable<ProductBrandViewModel>>(domains);
            return viewModels;
        }


        public ProductBrandViewModel Update(ProductBrandViewModel entity)
        {
            var domain = _mapper.Map<ProductBrand>(entity);
            domain = _repository.Update(domain);
            Commit();

            ProductBrandViewModel viewModel = _mapper.Map<ProductBrandViewModel>(domain);
            return viewModel;
        }
    }
}
