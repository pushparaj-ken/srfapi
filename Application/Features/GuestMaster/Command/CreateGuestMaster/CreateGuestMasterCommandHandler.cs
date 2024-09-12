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

namespace Application.Features.GuestMaster.Command.CreateGuestMaster;


public class CreateGuestMasterCommandHandler : IRequestHandler<CreateGuestMasterCommand, ApiResponse>
{
  private IMapper _mapper;
  private IGuestMasterRepository _guestMasterRepository;
  private IAppLogger<CreateGuestMasterCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public CreateGuestMasterCommandHandler(IMapper mapper, IGuestMasterRepository guestMasterRepository
    , IAppLogger<CreateGuestMasterCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._guestMasterRepository = guestMasterRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(CreateGuestMasterCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var createData = new DomainGuestMaster
      {
        Name = request.Name,
        OrgId = request.OrgId,
        Addline1 = request.Addline1,
        Addline2 = request.Addline2,
        Addline3 = request.Addline3,
        Addline4 = request.Addline4,
        Phoneno1 = request.Phoneno1,
        Phoneno2 = request.Phoneno2,
        Pincode = request.Pincode,
        Remarks = request.Remarks,
        CreatedOn = DateTime.Now
      };
      await _guestMasterRepository.CreateAsync(createData);

      return await _responseService.ApiSuccessResponse(createData);
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