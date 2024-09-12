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

namespace Application.Features.HostelMaster.Command.UpdateHostelMaster;


public class UpdateHostelMasterCommandHandler : IRequestHandler<UpdateHostelMasterCommand, ApiResponse>
{
  private IMapper _mapper;
  private IHostelMasterRepository _hostelMasterRepository;
  private IAppLogger<UpdateHostelMasterCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public UpdateHostelMasterCommandHandler(IMapper mapper, IHostelMasterRepository hostelMasterRepository
    , IAppLogger<UpdateHostelMasterCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._hostelMasterRepository = hostelMasterRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(UpdateHostelMasterCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var updateData = await _hostelMasterRepository.GetByIdAsync(request.Id);

      if (updateData == null)
      {
        return await _responseService.ApiFailResponse($"Room category with ID {request.Id} not found.");
      }
      updateData.Name = request.Name;
      updateData.OrgId = request.OrgId;
      updateData.SiteId = request.SiteId;
      updateData.No = request.No;
      updateData.Owner = request.Owner;
      updateData.OwnerNatid = request.OwnerNatid;
      updateData.Addline1 = request.Addline1;
      updateData.Addline2 = request.Addline2;
      updateData.Addline3 = request.Addline3;
      updateData.Addline4 = request.Addline4;
      updateData.Phoneno1 = request.Phoneno1;
      updateData.Phoneno2 = request.Phoneno2;
      updateData.Phoneno3 = request.Phoneno3;
      updateData.Zipcode = request.Zipcode;
      updateData.EmailId = request.EmailId;
      updateData.AddressLink = request.AddressLink;
      updateData.NextReneWaldate = request.NextReneWaldate;
      updateData.CurWardenName = request.CurWardenName;
      updateData.WardenContactNo = request.WardenContactNo;
      updateData.WardenMailId = request.WardenMailId;
      updateData.EbNo = request.EbNo;
      updateData.WaterNo = request.WaterNo;
      updateData.ZoneNo = request.ZoneNo;
      updateData.StreetNo = request.StreetNo;
      updateData.Capacity = request.Capacity;
      updateData.AppliCableSelGrade = request.AppliCableSelGrade;
      updateData.AppliCableSelForms = request.AppliCableSelForms;
      updateData.ModifiedOn = DateTime.Now;

      await _hostelMasterRepository.UpdateAsync(updateData);

      return await _responseService.ApiSuccessResponse(null);
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