using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Aplication.ViewMode1;
using VirtualStore.Domain.Entities;

namespace VirtualStore.Aplication.AutoMap
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ReverseMap();
        }
    }
}
