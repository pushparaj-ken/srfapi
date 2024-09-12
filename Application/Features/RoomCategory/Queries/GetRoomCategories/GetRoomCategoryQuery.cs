using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RoomCategory.Queries.GetAllRoomCategories;

public class GetRoomCategoryQuery : IRequest<ApiResponse>
{
    public int Id { get; set; }
}

