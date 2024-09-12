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

namespace Application.Features.HostelMaster.Queries.GetAllHostelMaster;

public class GetHostelMasterHandler : IRequestHandler<GetHostelMasterQuery, ApiResponse>
{
    private IMapper _mapper;
    private IHostelMasterRepository _hostelMasterRepository;
    private IAppLogger<GetHostelMasterHandler> _logger;
    private readonly APIResponseService _responseService;

    public GetHostelMasterHandler(IMapper mapper, IHostelMasterRepository hostelMasterRepository, IAppLogger<GetHostelMasterHandler> logger, APIResponseService responseService)
    {
        this._mapper = mapper;
        this._hostelMasterRepository = hostelMasterRepository;
        this._logger = logger;
        this._responseService = responseService;
    }

    public async Task<ApiResponse> Handle(GetHostelMasterQuery request,
       CancellationToken cancellationToken)
    {
        var getData = await _hostelMasterRepository.GetByIdAsync(request.Id);

        if (getData == null)
        {
            return await _responseService.ApiFailResponse($"Room category with ID {request.Id} not found.");
        }

        _logger.LogInformation($"Room Category with ID {request.Id} was retrieved successfully");

        return await _responseService.ApiSuccessResponse(getData);
    }
}
