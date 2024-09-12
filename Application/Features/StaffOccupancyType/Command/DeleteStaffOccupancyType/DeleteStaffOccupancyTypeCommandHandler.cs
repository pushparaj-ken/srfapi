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

namespace Application.Features.StaffOccupancyType.Command.DeleteStaffOccupancyType;


public class DeleteStaffOccupancyTypeCommandHandler : IRequestHandler<DeleteStaffOccupancyTypeCommand, ApiResponse>
{
  private IMapper _mapper;
  private IStaffOccupancyTypeRepository _staffOccupancyTypeRepository;
  private IAppLogger<DeleteStaffOccupancyTypeCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public DeleteStaffOccupancyTypeCommandHandler(IMapper mapper, IStaffOccupancyTypeRepository staffOccupancyTypeRepository
    , IAppLogger<DeleteStaffOccupancyTypeCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._staffOccupancyTypeRepository = staffOccupancyTypeRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(DeleteStaffOccupancyTypeCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var DeleteData = await _staffOccupancyTypeRepository.GetByIdAsync(request.Id);

      if (DeleteData == null)
      {
        return await _responseService.ApiFailResponse($"Room category with ID {request.Id} not found.");
      }

      await _staffOccupancyTypeRepository.DeleteASync(DeleteData);

      return await _responseService.ApiSuccessResponse(null);
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