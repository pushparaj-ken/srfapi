using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StaffOccupancyType.Command.UpdateStaffOccupancyType;

public class UpdateStaffOccupancyTypeCommand : IRequest<ApiResponse>
{
  public int Id { get; set; }

  public int OrgId { get; set; }

  public int SiteId { get; set; }

  public string TypeName { get; set; } = string.Empty;
}