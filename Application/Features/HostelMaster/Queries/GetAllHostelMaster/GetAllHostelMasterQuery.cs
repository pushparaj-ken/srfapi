using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HostelMaster.Queries.GetAllHostelMaster;

// Query for getting all asset categories
public record GetAllHostelMasterQuery : IRequest<ApiResponse>;



