using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Core.Enums;

namespace VirtualStore.Application.ViewModel
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "O Campo preço é obrigatório")]
        public Decimal Price { get; set; }

        public string PictureUri { get; set; }

        public ProductType Type { get; set; }

        public Guid BrandId { get; set; }
    }
}
