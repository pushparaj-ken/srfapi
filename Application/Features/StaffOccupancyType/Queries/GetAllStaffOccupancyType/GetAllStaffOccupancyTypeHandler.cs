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

public class GetAllStaffOccupancyTypeHandler : IRequestHandler<GetAllStaffOccupancyTypeQuery, ApiResponse>
{
    private IMapper _mapper;
    private IStaffOccupancyTypeRepository _staffOccupancyTypeRepository;
    private IAppLogger<GetAllStaffOccupancyTypeHandler> _logger;

    private readonly APIResponseService _responseService;

    public GetAllStaffOccupancyTypeHandler(IMapper mapper, IStaffOccupancyTypeRepository staffOccupancyTypeRepository, IAppLogger<GetAllStaffOccupancyTypeHandler> logger, APIResponseService responseService)
    {
        this._mapper = mapper;
        this._staffOccupancyTypeRepository = staffOccupancyTypeRepository;
        this._logger = logger;
        this._responseService = responseService;
    }

    public async Task<ApiResponse> Handle(GetAllStaffOccupancyTypeQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var getAllData = await _staffOccupancyTypeRepository.GetAsync();
            if (getAllData == null)
            {
                return await _responseService.ApiFailResponse($"Room category not found.");
            }
            _logger.LogInformation("Room Categories were retrieved successfully");

            return await _responseService.ApiSuccessResponse(getAllData);
        }
        catch (Exception ex)
        {
            _logger.LogWarning($"Error saving StaffOccupancyType: {ex.Message}", ex);
            if (ex.InnerException != null)
            {
                _logger.LogWarning($"Inner Exception: {ex.InnerException.Message}");
            }
            throw new BadRequestException($"Error at StaffOccupancyType: {ex.Message}");
        }
    }

}
