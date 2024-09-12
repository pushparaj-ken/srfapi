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

namespace Application.Features.StudOccupancyType.Queries.GetAllStudOccupancyType;

public class GetAllStudOccupancyTypeHandler : IRequestHandler<GetAllStudOccupancyTypeQuery, ApiResponse>
{
    private IMapper _mapper;
    private IStudOccupancyTypeRepository _studOccupancyTypeRepository;
    private IAppLogger<GetAllStudOccupancyTypeHandler> _logger;

    private readonly APIResponseService _responseService;

    public GetAllStudOccupancyTypeHandler(IMapper mapper, IStudOccupancyTypeRepository studOccupancyTypeRepository, IAppLogger<GetAllStudOccupancyTypeHandler> logger, APIResponseService responseService)
    {
        this._mapper = mapper;
        this._studOccupancyTypeRepository = studOccupancyTypeRepository;
        this._logger = logger;
        this._responseService = responseService;
    }

    public async Task<ApiResponse> Handle(GetAllStudOccupancyTypeQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var getAllData = await _studOccupancyTypeRepository.GetAsync();
            if (getAllData == null)
            {
                return await _responseService.ApiFailResponse($"Room category not found.");
            }
            _logger.LogInformation("Room Categories were retrieved successfully");

            return await _responseService.ApiSuccessResponse(getAllData);
        }
        catch (Exception ex)
        {
            _logger.LogWarning($"Error saving StudOccupancyType: {ex.Message}", ex);
            if (ex.InnerException != null)
            {
                _logger.LogWarning($"Inner Exception: {ex.InnerException.Message}");
            }
            throw new BadRequestException($"Error at StudOccupancyType: {ex.Message}");
        }
    }

}
