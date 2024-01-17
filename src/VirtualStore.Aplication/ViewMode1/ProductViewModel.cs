using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Core.Enums;

namespace VirtualStore.Aplication.ViewMode1
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo Preço é obrigatório")]
        public decimal Price { get; set; } 
        public string PictureUry { get; set; }
        public ProductType productType { get; set; }
        public Guid BrandId { get; set; }
    }
}
