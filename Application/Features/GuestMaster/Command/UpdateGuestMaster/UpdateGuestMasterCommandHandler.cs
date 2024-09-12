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

namespace Application.Features.GuestMaster.Command.UpdateGuestMaster;


public class UpdateGuestMasterCommandHandler : IRequestHandler<UpdateGuestMasterCommand, ApiResponse>
{
  private IMapper _mapper;
  private IGuestMasterRepository _guestMasterRepository;
  private IAppLogger<UpdateGuestMasterCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public UpdateGuestMasterCommandHandler(IMapper mapper, IGuestMasterRepository guestMasterRepository
    , IAppLogger<UpdateGuestMasterCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._guestMasterRepository = guestMasterRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(UpdateGuestMasterCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var updateData = await _guestMasterRepository.GetByIdAsync(request.Id);

      if (updateData == null)
      {
        return await _responseService.ApiFailResponse($"Room category with ID {request.Id} not found.");
      }
      updateData.Name = request.Name;
      updateData.OrgId = request.OrgId;
      updateData.Addline1 = request.Addline1;
      updateData.Addline2 = request.Addline2;
      updateData.Addline3 = request.Addline3;
      updateData.Addline4 = request.Addline4;
      updateData.Phoneno1 = request.Phoneno1;
      updateData.Phoneno2 = request.Phoneno2;
      updateData.Pincode = request.Pincode;
      updateData.Remarks = request.Remarks;
      updateData.ModifiedOn = DateTime.Now;

      await _guestMasterRepository.UpdateAsync(updateData);

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