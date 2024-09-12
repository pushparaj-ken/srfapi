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

namespace Application.Features.GuestMaster.Queries.GetAllGuestMaster;

public class GetAllGuestMasterHandler : IRequestHandler<GetAllGuestMasterQuery, ApiResponse>
{
    private IMapper _mapper;
    private IGuestMasterRepository _guestMasterRepository;
    private IAppLogger<GetAllGuestMasterHandler> _logger;

    private readonly APIResponseService _responseService;

    public GetAllGuestMasterHandler(IMapper mapper, IGuestMasterRepository guestMasterRepository, IAppLogger<GetAllGuestMasterHandler> logger, APIResponseService responseService)
    {
        this._mapper = mapper;
        this._guestMasterRepository = guestMasterRepository;
        this._logger = logger;
        this._responseService = responseService;
    }

    public async Task<ApiResponse> Handle(GetAllGuestMasterQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var getAllData = await _guestMasterRepository.GetAsync();
            if (getAllData == null)
            {
                return await _responseService.ApiFailResponse($"Room category not found.");
            }
            _logger.LogInformation("Room Categories were retrieved successfully");

            return await _responseService.ApiSuccessResponse(getAllData);
        }
        catch (Exception ex)
        {
            _logger.LogWarning($"Error saving GuestMaster: {ex.Message}", ex);
            if (ex.InnerException != null)
            {
                _logger.LogWarning($"Inner Exception: {ex.InnerException.Message}");
            }
            throw new BadRequestException($"Error at GuestMaster: {ex.Message}");
        }
    }

}
