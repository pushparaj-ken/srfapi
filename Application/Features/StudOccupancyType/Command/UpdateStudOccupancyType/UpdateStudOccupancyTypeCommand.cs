using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudOccupancyType.Command.UpdateStudOccupancyType;

public class UpdateStudOccupancyTypeCommand : IRequest<ApiResponse>
{
  public int Id { get; set; }

  public int OrgId { get; set; }

  public int SiteId { get; set; }

  public string TypeName { get; set; } = string.Empty;
}