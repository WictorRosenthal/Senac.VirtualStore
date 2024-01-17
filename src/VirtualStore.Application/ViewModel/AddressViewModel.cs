using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Core.Enums;

namespace VirtualStore.Application.ViewModel
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo cidade é obrigatório")]
        public string Street { get; set; }
        public string Complement { get; set; }

        public string Neighborhood { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}
