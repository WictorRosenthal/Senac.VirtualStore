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
    public class AddressAppService : BaseService, IAddressAppService
    {
        protected IAddressRepository _repository;
        protected IMapper _mapper;

        public AddressAppService(IAddressRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediator bus) : base(unitOfWork, bus)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public AddressViewModel Add(AddressViewModel entity)
        {
            Address domain = _mapper.Map<Address>(entity);
            domain = _repository.Add(domain);
            Commit();

            AddressViewModel viewModel = _mapper.Map<AddressViewModel>(domain);
            return viewModel;
        }

        public AddressViewModel GetById(Guid Id)
        {
            var domain = _repository.GetById(Id);
            var viewModel = _mapper.Map<AddressViewModel>(domain);
            return viewModel;
        }

        public void Remove(Guid Id)
        {
            _repository.Remove(Id);
            Commit();
        }

        public void Remove(Expression<Func<Address, bool>> predicate)
        {
            _repository.Remove(predicate);
            Commit();
        }

        public IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> predicate)
        {
            IEnumerable<Address> domains = _repository.Search(predicate);
            IEnumerable<AddressViewModel> viewModels = _mapper.Map<IEnumerable<AddressViewModel>>(domains);
            return viewModels;
        }

        public IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> predicate,
            int pageNumber, int pageSize)
        {
            var domains = _repository.Search(predicate, pageNumber, pageSize);
            var viewModels = _mapper.Map<IEnumerable<AddressViewModel>>(domains);
            return viewModels;
        }


        public AddressViewModel Update(AddressViewModel entity)
        {
            var domain = _mapper.Map<Address>(entity);
            domain = _repository.Update(domain);
            Commit();

            AddressViewModel viewModel = _mapper.Map<AddressViewModel>(domain);
            return viewModel;
        }

    }
}
