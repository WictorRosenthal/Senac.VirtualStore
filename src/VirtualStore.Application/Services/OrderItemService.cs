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
    public class OrderItemAppService : BaseService, IOrderItemAppService
    {
        protected IOrderItemRepository _repository;
        protected IMapper _mapper;

        public OrderItemAppService(IOrderItemRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediator bus) : base(unitOfWork, bus)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public OrderItemViewModel Add(OrderItemViewModel entity)
        {
            OrderItem domain = _mapper.Map<OrderItem>(entity);
            domain = _repository.Add(domain);
            Commit();

            OrderItemViewModel viewModel = _mapper.Map<OrderItemViewModel>(domain);
            return viewModel;
        }

        public OrderItemViewModel GetById(Guid Id)
        {
            var domain = _repository.GetById(Id);
            var viewModel = _mapper.Map<OrderItemViewModel>(domain);
            return viewModel;
        }

        public void Remove(Guid Id)
        {
            _repository.Remove(Id);
            Commit();
        }

        public void Remove(Expression<Func<OrderItem, bool>> predicate)
        {
            _repository.Remove(predicate);
            Commit();
        }

        public IEnumerable<OrderItemViewModel> Search(Expression<Func<OrderItem, bool>> predicate)
        {
            IEnumerable<OrderItem> domains = _repository.Search(predicate);
            IEnumerable<OrderItemViewModel> viewModels = _mapper.Map<IEnumerable<OrderItemViewModel>>(domains);
            return viewModels;
        }

        public IEnumerable<OrderItemViewModel> Search(Expression<Func<OrderItem, bool>> predicate,
            int pageNumber, int pageSize)
        {
            var domains = _repository.Search(predicate, pageNumber, pageSize);
            var viewModels = _mapper.Map<IEnumerable<OrderItemViewModel>>(domains);
            return viewModels;
        }


        public OrderItemViewModel Update(OrderItemViewModel entity)
        {
            var domain = _mapper.Map<OrderItem>(entity);
            domain = _repository.Update(domain);
            Commit();

            OrderItemViewModel viewModel = _mapper.Map<OrderItemViewModel>(domain);
            return viewModel;
        }

    }
}
