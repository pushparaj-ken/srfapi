using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using DomainHostelMaster = Domain.HostelMaster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;

namespace Application.Features.HostelMaster.Command.CreateHostelMaster;


public class CreateHostelMasterCommandHandler : IRequestHandler<CreateHostelMasterCommand, ApiResponse>
{
  private IMapper _mapper;
  private IHostelMasterRepository _hostelMasterRepository;
  private IAppLogger<CreateHostelMasterCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public CreateHostelMasterCommandHandler(IMapper mapper, IHostelMasterRepository hostelMasterRepository
    , IAppLogger<CreateHostelMasterCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._hostelMasterRepository = hostelMasterRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(CreateHostelMasterCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var createData = new DomainHostelMaster
      {
        Name = request.Name,
        No = request.No,
        SiteId = request.SiteId,
        OrgId = request.OrgId,
        Owner = request.Owner,
        OwnerNatid = request.OwnerNatid,
        Addline1 = request.Addline1,
        Addline2 = request.Addline2,
        Addline3 = request.Addline3,
        Addline4 = request.Addline4,
        Phoneno1 = request.Phoneno1,
        Phoneno2 = request.Phoneno2,
        Phoneno3 = request.Phoneno3,
        Zipcode = request.Zipcode,
        EmailId = request.EmailId,
        AddressLink = request.AddressLink,
        NextReneWaldate = request.NextReneWaldate,
        CurWardenName = request.CurWardenName,
        WardenContactNo = request.WardenContactNo,
        WardenMailId = request.WardenMailId,
        EbNo = request.EbNo,
        WaterNo = request.WaterNo,
        ZoneNo = request.ZoneNo,
        StreetNo = request.StreetNo,
        Capacity = request.Capacity,
        AppliCableSelGrade = request.AppliCableSelGrade,
        AppliCableSelForms = request.AppliCableSelForms,
        CreatedOn = DateTime.Now
      };
      await _hostelMasterRepository.CreateAsync(createData);

      return await _responseService.ApiSuccessResponse(createData);
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