using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StaffOccupancyType.Command.CreateStaffOccupancyType;

public class CreateStaffOccupancyTypeCommand : IRequest<ApiResponse>
{
    public int OrgId { get; set; }

    public int SiteId { get; set; }

    public string TypeName { get; set; } = string.Empty;
}