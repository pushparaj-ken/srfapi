using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using DomainGuestMaster = Domain.GuestMaster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;

namespace Application.Features.GuestMaster.Command.DeleteGuestMaster;


public class DeleteGuestMasterCommandHandler : IRequestHandler<DeleteGuestMasterCommand, ApiResponse>
{
  private IMapper _mapper;
  private IGuestMasterRepository _guestMasterRepository;
  private IAppLogger<DeleteGuestMasterCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public DeleteGuestMasterCommandHandler(IMapper mapper, IGuestMasterRepository guestMasterRepository
    , IAppLogger<DeleteGuestMasterCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._guestMasterRepository = guestMasterRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(DeleteGuestMasterCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var DeleteData = await _guestMasterRepository.GetByIdAsync(request.Id);

      if (DeleteData == null)
      {
        return await _responseService.ApiFailResponse($"Room category with ID {request.Id} not found.");
      }

      await _guestMasterRepository.DeleteASync(DeleteData);

      return await _responseService.ApiSuccessResponse(null);
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