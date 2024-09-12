using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudOccupancyType.Command.DeleteStudOccupancyType;

public class DeleteStudOccupancyTypeCommand : IRequest<ApiResponse>
{
  public int Id { get; set; }
}