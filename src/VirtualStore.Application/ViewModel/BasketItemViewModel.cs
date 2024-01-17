using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Core.Enums;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Application.ViewModel
{
    public class BasketItemViewModel
    {
        public Guid Id { get; set; }
        public Guid BasketId { get; set; }

        public Basket Basket { get; set; }

        [Required(ErrorMessage = "O Campo preço é obrigatório")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage = "O campo quantidade é obrigatório")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "O campo Produto é obrigatório")]
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        

        

        
    }
}
