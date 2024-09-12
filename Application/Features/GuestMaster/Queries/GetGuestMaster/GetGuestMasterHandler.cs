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

public class GetGuestMasterHandler : IRequestHandler<GetGuestMasterQuery, ApiResponse>
{
    private IMapper _mapper;
    private IGuestMasterRepository _guestMasterRepository;
    private IAppLogger<GetGuestMasterHandler> _logger;
    private readonly APIResponseService _responseService;

    public GetGuestMasterHandler(IMapper mapper, IGuestMasterRepository guestMasterRepository, IAppLogger<GetGuestMasterHandler> logger, APIResponseService responseService)
    {
        this._mapper = mapper;
        this._guestMasterRepository = guestMasterRepository;
        this._logger = logger;
        this._responseService = responseService;
    }

    public async Task<ApiResponse> Handle(GetGuestMasterQuery request,
       CancellationToken cancellationToken)
    {
        var getData = await _guestMasterRepository.GetByIdAsync(request.Id);

        if (getData == null)
        {
            return await _responseService.ApiFailResponse($"Room category with ID {request.Id} not found.");
        }

        _logger.LogInformation($"Room Category with ID {request.Id} was retrieved successfully");

        return await _responseService.ApiSuccessResponse(getData);
    }
}
