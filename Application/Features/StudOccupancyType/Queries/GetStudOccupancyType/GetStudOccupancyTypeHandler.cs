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

public class GetStudOccupancyTypeHandler : IRequestHandler<GetStudOccupancyTypeQuery, ApiResponse>
{
    private IMapper _mapper;
    private IStudOccupancyTypeRepository _studOccupancyTypeRepository;
    private IAppLogger<GetStudOccupancyTypeHandler> _logger;
    private readonly APIResponseService _responseService;

    public GetStudOccupancyTypeHandler(IMapper mapper, IStudOccupancyTypeRepository studOccupancyTypeRepository, IAppLogger<GetStudOccupancyTypeHandler> logger, APIResponseService responseService)
    {
        this._mapper = mapper;
        this._studOccupancyTypeRepository = studOccupancyTypeRepository;
        this._logger = logger;
        this._responseService = responseService;
    }

    public async Task<ApiResponse> Handle(GetStudOccupancyTypeQuery request,
       CancellationToken cancellationToken)
    {
        var getData = await _studOccupancyTypeRepository.GetByIdAsync(request.Id);

        if (getData == null)
        {
            return await _responseService.ApiFailResponse($"Room category with ID {request.Id} not found.");
        }

        _logger.LogInformation($"Room Category with ID {request.Id} was retrieved successfully");

        return await _responseService.ApiSuccessResponse(getData);
    }
}
