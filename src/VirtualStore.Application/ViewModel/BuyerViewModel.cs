using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Application.ViewModel
{
    public class BuyerViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Guid AddressId { get; set; }
        public Address PrincipalAddress { get; set; }
        public string Phone { get; set; }
        public string Document { get; set; }
        public string Gender { get; set; }
    }
}
