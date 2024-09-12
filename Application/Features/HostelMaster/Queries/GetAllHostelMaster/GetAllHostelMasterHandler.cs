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

public class GetAllHostelMasterHandler : IRequestHandler<GetAllHostelMasterQuery, ApiResponse>
{
    private IMapper _mapper;
    private IHostelMasterRepository _hostelMasterRepository;
    private IAppLogger<GetAllHostelMasterHandler> _logger;

    private readonly APIResponseService _responseService;

    public GetAllHostelMasterHandler(IMapper mapper, IHostelMasterRepository hostelMasterRepository, IAppLogger<GetAllHostelMasterHandler> logger, APIResponseService responseService)
    {
        this._mapper = mapper;
        this._hostelMasterRepository = hostelMasterRepository;
        this._logger = logger;
        this._responseService = responseService;
    }

    public async Task<ApiResponse> Handle(GetAllHostelMasterQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var getAllData = await _hostelMasterRepository.GetAsync();
            if (getAllData == null)
            {
                return await _responseService.ApiFailResponse($"Room category not found.");
            }
            _logger.LogInformation("Room Categories were retrieved successfully");

            return await _responseService.ApiSuccessResponse(getAllData);
        }
        catch (Exception ex)
        {
            _logger.LogWarning($"Error saving HostelMaster: {ex.Message}", ex);
            if (ex.InnerException != null)
            {
                _logger.LogWarning($"Inner Exception: {ex.InnerException.Message}");
            }
            throw new BadRequestException($"Error at HostelMaster: {ex.Message}");
        }
    }

}
