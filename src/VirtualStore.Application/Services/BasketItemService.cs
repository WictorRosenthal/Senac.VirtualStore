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
    public class BasketItemAppService : BaseService, IBasketItemAppService
    {
        protected IBasketItemRepository _repository;
        protected IMapper _mapper;

        public BasketItemAppService(IBasketItemRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediator bus) : base(unitOfWork, bus)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public BasketItemViewModel Add(BasketItemViewModel entity)
        {
            BasketItem domain = _mapper.Map<BasketItem>(entity);
            domain = _repository.Add(domain);
            Commit();

            BasketItemViewModel viewModel = _mapper.Map<BasketItemViewModel>(domain);
            return viewModel;
        }

        public BasketItemViewModel GetById(Guid Id)
        {
            var domain = _repository.GetById(Id);
            var viewModel = _mapper.Map<BasketItemViewModel>(domain);
            return viewModel;
        }

        public void Remove(Guid Id)
        {
            _repository.Remove(Id);
            Commit();
        }

        public void Remove(Expression<Func<BasketItem, bool>> predicate)
        {
            _repository.Remove(predicate);
            Commit();
        }

        public IEnumerable<BasketItemViewModel> Search(Expression<Func<BasketItem, bool>> predicate)
        {
            IEnumerable<BasketItem> domains = _repository.Search(predicate);
            IEnumerable<BasketItemViewModel> viewModels = _mapper.Map<IEnumerable<BasketItemViewModel>>(domains);
            return viewModels;
        }

        public IEnumerable<BasketItemViewModel> Search(Expression<Func<BasketItem, bool>> predicate,
            int pageNumber, int pageSize)
        {
            var domains = _repository.Search(predicate, pageNumber, pageSize);
            var viewModels = _mapper.Map<IEnumerable<BasketItemViewModel>>(domains);
            return viewModels;
        }


        public BasketItemViewModel Update(BasketItemViewModel entity)
        {
            var domain = _mapper.Map<BasketItem>(entity);
            domain = _repository.Update(domain);
            Commit();

            BasketItemViewModel viewModel = _mapper.Map<BasketItemViewModel>(domain);
            return viewModel;
        }

    }
}
