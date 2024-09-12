using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RoomCategory.Command.UpdateRoomCategory;

public class UpdateRoomCategoryCommand : IRequest<ApiResponse>
{
  public int Id { get; set; }

  public string Name { get; set; } = string.Empty;

  public int OrgId { get; set; }
}