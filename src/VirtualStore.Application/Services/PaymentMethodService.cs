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
    public class PaymentMethodAppService : BaseService, IPaymentMethodAppService
    {
        protected IPaymentMethodRepository _repository;
        protected IMapper _mapper;

        public PaymentMethodAppService(IPaymentMethodRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediator bus) : base(unitOfWork, bus)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public PaymentMethodViewModel Add(PaymentMethodViewModel entity)
        {
            PaymentMethod domain = _mapper.Map<PaymentMethod>(entity);
            domain = _repository.Add(domain);
            Commit();

            PaymentMethodViewModel viewModel = _mapper.Map<PaymentMethodViewModel>(domain);
            return viewModel;
        }

        public PaymentMethodViewModel GetById(Guid Id)
        {
            var domain = _repository.GetById(Id);
            var viewModel = _mapper.Map<PaymentMethodViewModel>(domain);
            return viewModel;
        }

        public void Remove(Guid Id)
        {
            _repository.Remove(Id);
            Commit();
        }

        public void Remove(Expression<Func<PaymentMethod, bool>> predicate)
        {
            _repository.Remove(predicate);
            Commit();
        }

        public IEnumerable<PaymentMethodViewModel> Search(Expression<Func<PaymentMethod, bool>> predicate)
        {
            IEnumerable<PaymentMethod> domains = _repository.Search(predicate);
            IEnumerable<PaymentMethodViewModel> viewModels = _mapper.Map<IEnumerable<PaymentMethodViewModel>>(domains);
            return viewModels;
        }

        public IEnumerable<PaymentMethodViewModel> Search(Expression<Func<PaymentMethod, bool>> predicate,
            int pageNumber, int pageSize)
        {
            var domains = _repository.Search(predicate, pageNumber, pageSize);
            var viewModels = _mapper.Map<IEnumerable<PaymentMethodViewModel>>(domains);
            return viewModels;
        }


        public PaymentMethodViewModel Update(PaymentMethodViewModel entity)
        {
            var domain = _mapper.Map<PaymentMethod>(entity);
            domain = _repository.Update(domain);
            Commit();

            PaymentMethodViewModel viewModel = _mapper.Map<PaymentMethodViewModel>(domain);
            return viewModel;
        }

    }
}
