using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudOccupancyType.Queries.GetAllStudOccupancyType;

// Query for getting all asset categories
public record GetAllStudOccupancyTypeQuery : IRequest<ApiResponse>;



