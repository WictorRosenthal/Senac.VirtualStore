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
    public class OrderAppService : BaseService, IOrderAppService
    {
        protected IOrderRepository _repository;
        protected IMapper _mapper;

        public OrderAppService(IOrderRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediator bus) : base(unitOfWork, bus)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public OrderViewModel Add(OrderViewModel entity)
        {
            Order domain = _mapper.Map<Order>(entity);
            domain = _repository.Add(domain);
            Commit();

            OrderViewModel viewModel = _mapper.Map<OrderViewModel>(domain);
            return viewModel;
        }

        public OrderViewModel GetById(Guid Id)
        {
            var domain = _repository.GetById(Id);
            var viewModel = _mapper.Map<OrderViewModel>(domain);
            return viewModel;
        }

        public void Remove(Guid Id)
        {
            _repository.Remove(Id);
            Commit();
        }

        public void Remove(Expression<Func<Order, bool>> predicate)
        {
            _repository.Remove(predicate);
            Commit();
        }

        public IEnumerable<OrderViewModel> Search(Expression<Func<Order, bool>> predicate)
        {
            IEnumerable<Order> domains = _repository.Search(predicate);
            IEnumerable<OrderViewModel> viewModels = _mapper.Map<IEnumerable<OrderViewModel>>(domains);
            return viewModels;
        }

        public IEnumerable<OrderViewModel> Search(Expression<Func<Order, bool>> predicate,
            int pageNumber, int pageSize)
        {
            var domains = _repository.Search(predicate, pageNumber, pageSize);
            var viewModels = _mapper.Map<IEnumerable<OrderViewModel>>(domains);
            return viewModels;
        }


        public OrderViewModel Update(OrderViewModel entity)
        {
            var domain = _mapper.Map<Order>(entity);
            domain = _repository.Update(domain);
            Commit();

            OrderViewModel viewModel = _mapper.Map<OrderViewModel>(domain);
            return viewModel;
        }

    }
}
