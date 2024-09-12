using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using DomainStaffOccupancyType = Domain.StaffOccupancyType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;

namespace Application.Features.StaffOccupancyType.Command.CreateStaffOccupancyType;


public class CreateStaffOccupancyTypeCommandHandler : IRequestHandler<CreateStaffOccupancyTypeCommand, ApiResponse>
{
  private IMapper _mapper;
  private IStaffOccupancyTypeRepository _staffOccupancyTypeRepository;
  private IAppLogger<CreateStaffOccupancyTypeCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public CreateStaffOccupancyTypeCommandHandler(IMapper mapper, IStaffOccupancyTypeRepository staffOccupancyTypeRepository
    , IAppLogger<CreateStaffOccupancyTypeCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._staffOccupancyTypeRepository = staffOccupancyTypeRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(CreateStaffOccupancyTypeCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var createData = new DomainStaffOccupancyType
      {
        TypeName = request.TypeName,
        OrgId = request.OrgId,
        SiteId = request.SiteId,
        CreatedOn = DateTime.Now
      };
      await _staffOccupancyTypeRepository.CreateAsync(createData);

      return await _responseService.ApiSuccessResponse(createData);
    }
    catch (Exception ex)
    {
      _logger.LogWarning($"Error saving StaffOccupancyType: {ex.Message}", ex);
      if (ex.InnerException != null)
      {
        _logger.LogWarning($"Inner Exception: {ex.InnerException.Message}");
      }
      throw new BadRequestException($"Error at StaffOccupancyType: {ex.Message}");
    }
  }

}