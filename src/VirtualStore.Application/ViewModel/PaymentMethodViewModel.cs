using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Application.ViewModel
{
    public class PaymentMethodViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string CardBrand { get; set; } 
        public Guid CardId { get;  set; } 
        public string Last4 { get;  set; }

        public Guid BuyerId { get;  set; }
        public Buyer Buyer { get;  set; }
    }
}
