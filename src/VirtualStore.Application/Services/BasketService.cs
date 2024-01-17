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
    public class BasketAppService : BaseService, IBasketAppService
    {
        protected IBasketRepository _repository;
        protected IMapper _mapper;

        public BasketAppService(IBasketRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediator bus) : base(unitOfWork, bus)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public BasketViewModel Add(BasketViewModel entity)
        {
            Basket domain = _mapper.Map<Basket>(entity);
            domain = _repository.Add(domain);
            Commit();

            BasketViewModel viewModel = _mapper.Map<BasketViewModel>(domain);
            return viewModel;
        }

        public BasketViewModel GetById(Guid Id)
        {
            var domain = _repository.GetById(Id);
            var viewModel = _mapper.Map<BasketViewModel>(domain);
            return viewModel;
        }

        public void Remove(Guid Id)
        {
            _repository.Remove(Id);
            Commit();
        }

        public void Remove(Expression<Func<Basket, bool>> predicate)
        {
            _repository.Remove(predicate);
            Commit();
        }

        public IEnumerable<BasketViewModel> Search(Expression<Func<Basket, bool>> predicate)
        {
            IEnumerable<Basket> domains = _repository.Search(predicate);
            IEnumerable<BasketViewModel> viewModels = _mapper.Map<IEnumerable<BasketViewModel>>(domains);
            return viewModels;
        }

        public IEnumerable<BasketViewModel> Search(Expression<Func<Basket, bool>> predicate,
            int pageNumber, int pageSize)
        {
            var domains = _repository.Search(predicate, pageNumber, pageSize);
            var viewModels = _mapper.Map<IEnumerable<BasketViewModel>>(domains);
            return viewModels;
        }


        public BasketViewModel Update(BasketViewModel entity)
        {
            var domain = _mapper.Map<Basket>(entity);
            domain = _repository.Update(domain);
            Commit();

            BasketViewModel viewModel = _mapper.Map<BasketViewModel>(domain);
            return viewModel;
        }
    }
}
