using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Application.ViewModel
{
    public class OrderItemViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }

        [Required(ErrorMessage = "O Campo preço é obrigatório")]
        public decimal UnitValue { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
