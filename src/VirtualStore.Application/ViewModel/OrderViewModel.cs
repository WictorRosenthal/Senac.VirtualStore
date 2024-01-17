﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Application.ViewModel
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public Guid BuyerId { get; set; }
        public Guid AddressId { get; set; }

        public Address Address { get; set; }
        public Buyer Buyer { get; set; }

        [Required(ErrorMessage = "O Campo preço é obrigatório")]
        public decimal TotalValue { get; set; }
        public decimal Discount { get; set; }
        

    }
}
