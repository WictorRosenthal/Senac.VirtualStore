using System;
using System.Linq.Expressions;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Domain.Interfaces
{
	public interface IAddressRepository
	{
		//Traz um item pelo Id dele
		Address GetById(Guid Id);
		//Traz N itens de acordo com uma(s) condição(ões)
		IEnumerable<Address> Search(Expression<Func<Address, bool>> predicate);
		//Traz N itens de acordo com uma(s) condiçõa(ões) e o número da página e a quantidade de itens na página
		//PAGINAÇÃO
		IEnumerable<Address> Search(Expression<Func<Address, bool>> predicate,
			int pageNumber,
			int pageSize);
		//Adiciona um item
		Address Add(Address entity);
		//Altera um item
		Address Update(Address entity);
		//Remove um único item
		void Remove(Guid Id);
		//Remove os itens que condizem com a(s) minha(s) condição(ões)
		void Remove(Expression<Func<Address, bool>> predicate);
	}
}

