using Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.AssetCategory.Queries.GetAllAssetCategories;

namespace Application.MappingProfiles
{
    public class AssetCategoryProfile : Profile
    {
        public AssetCategoryProfile() 
        {
            CreateMap<AssetCategoryDto, AssetCategory>().ReverseMap();
        }
    }
}
