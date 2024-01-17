using AutoMapper;
using MediatR;
using System.Linq.Expressions;
using VirtualStore.Application.Interfaces;
using VirtualStore.Application.ViewModel;
using VirtualStore.Core.UoW;
using VirtualStore.Domain.Entities;
using VirtualStore.Domain.Interfaces;

namespace VirtualStore.Application.Services
{
    public class ProductAppService : BaseService, IProductAppService
    {
        protected IProductRepository _repository;
        protected IMapper _mapper;

        public ProductAppService(IProductRepository repository,
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

            ProductViewModel viewModel = _mapper.Map<ProductViewModel>(domain);
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
            IEnumerable<Product> domains = _repository.Search(predicate);
            IEnumerable<ProductViewModel> viewModels = _mapper.Map<IEnumerable<ProductViewModel>>(domains);
            return viewModels;
        }

        public IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> predicate,
            int pageNumber, int pageSize)
        {
            var domains = _repository.Search(predicate, pageNumber, pageSize);
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
