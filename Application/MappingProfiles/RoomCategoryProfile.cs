using Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.RoomCategory.Queries.GetAllRoomCategories;

namespace Application.MappingProfiles
{
  public class RoomCategoryProfile : Profile
  {
    public RoomCategoryProfile()
    {
      CreateMap<RoomCategoryDto, RoomCategory>().ReverseMap();
    }
  }
}
