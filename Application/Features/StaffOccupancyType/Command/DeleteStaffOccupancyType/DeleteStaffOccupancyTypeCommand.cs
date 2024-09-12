using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StaffOccupancyType.Command.DeleteStaffOccupancyType;

public class DeleteStaffOccupancyTypeCommand : IRequest<ApiResponse>
{
  public int Id { get; set; }
}