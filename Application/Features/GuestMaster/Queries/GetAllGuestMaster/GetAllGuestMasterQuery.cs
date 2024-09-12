using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GuestMaster.Queries.GetAllGuestMaster;

// Query for getting all asset categories
public record GetAllGuestMasterQuery : IRequest<ApiResponse>;



