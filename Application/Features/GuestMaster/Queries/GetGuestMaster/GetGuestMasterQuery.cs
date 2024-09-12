using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GuestMaster.Queries.GetAllGuestMaster;

public class GetGuestMasterQuery : IRequest<ApiResponse>
{
    public int Id { get; set; }
}

