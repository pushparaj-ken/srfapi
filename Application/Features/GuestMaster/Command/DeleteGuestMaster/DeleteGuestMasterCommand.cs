using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GuestMaster.Command.DeleteGuestMaster;

public class DeleteGuestMasterCommand : IRequest<ApiResponse>
{
  public int Id { get; set; }
}