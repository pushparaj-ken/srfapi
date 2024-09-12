using Application.Common;
using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StaffOccupancyType.Queries.GetAllStaffOccupancyType;

public class GetStaffOccupancyTypeHandler : IRequestHandler<GetStaffOccupancyTypeQuery, ApiResponse>
{
    private IMapper _mapper;
    private IStaffOccupancyTypeRepository _staffOccupancyTypeRepository;
    private IAppLogger<GetStaffOccupancyTypeHandler> _logger;
    private readonly APIResponseService _responseService;

    public GetStaffOccupancyTypeHandler(IMapper mapper, IStaffOccupancyTypeRepository staffOccupancyTypeRepository, IAppLogger<GetStaffOccupancyTypeHandler> logger, APIResponseService responseService)
    {
        this._mapper = mapper;
        this._staffOccupancyTypeRepository = staffOccupancyTypeRepository;
        this._logger = logger;
        this._responseService = responseService;
    }

    public async Task<ApiResponse> Handle(GetStaffOccupancyTypeQuery request,
       CancellationToken cancellationToken)
    {
        var getData = await _staffOccupancyTypeRepository.GetByIdAsync(request.Id);

        if (getData == null)
        {
            return await _responseService.ApiFailResponse($"Room category with ID {request.Id} not found.");
        }

        _logger.LogInformation($"Room Category with ID {request.Id} was retrieved successfully");

        return await _responseService.ApiSuccessResponse(getData);
    }
}
