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
    public class BuyerAppService : BaseService, IBuyerAppService
    {
        protected IBuyerRepository _repository;
        protected IMapper _mapper;

        public BuyerAppService(IBuyerRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediator bus) : base(unitOfWork, bus)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public BuyerViewModel Add(BuyerViewModel entity)
        {
            Buyer domain = _mapper.Map<Buyer>(entity);
            domain = _repository.Add(domain);
            Commit();

            BuyerViewModel viewModel = _mapper.Map<BuyerViewModel>(domain);
            return viewModel;
        }

        public BuyerViewModel GetById(Guid Id)
        {
            var domain = _repository.GetById(Id);
            var viewModel = _mapper.Map<BuyerViewModel>(domain);
            return viewModel;
        }

        public void Remove(Guid Id)
        {
            _repository.Remove(Id);
            Commit();
        }

        public void Remove(Expression<Func<Buyer, bool>> predicate)
        {
            _repository.Remove(predicate);
            Commit();
        }

        public IEnumerable<BuyerViewModel> Search(Expression<Func<Buyer, bool>> predicate)
        {
            IEnumerable<Buyer> domains = _repository.Search(predicate);
            IEnumerable<BuyerViewModel> viewModels = _mapper.Map<IEnumerable<BuyerViewModel>>(domains);
            return viewModels;
        }

        public IEnumerable<BuyerViewModel> Search(Expression<Func<Buyer, bool>> predicate,
            int pageNumber, int pageSize)
        {
            var domains = _repository.Search(predicate, pageNumber, pageSize);
            var viewModels = _mapper.Map<IEnumerable<BuyerViewModel>>(domains);
            return viewModels;
        }


        public BuyerViewModel Update(BuyerViewModel entity)
        {
            var domain = _mapper.Map<Buyer>(entity);
            domain = _repository.Update(domain);
            Commit();

            BuyerViewModel viewModel = _mapper.Map<BuyerViewModel>(domain);
            return viewModel;
        }

    }
}
