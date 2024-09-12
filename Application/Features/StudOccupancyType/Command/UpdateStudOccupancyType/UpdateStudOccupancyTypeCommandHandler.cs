using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using DomainStudOccupancyType = Domain.StudOccupancyType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;

namespace Application.Features.StudOccupancyType.Command.UpdateStudOccupancyType;


public class UpdateStudOccupancyTypeCommandHandler : IRequestHandler<UpdateStudOccupancyTypeCommand, ApiResponse>
{
  private IMapper _mapper;
  private IStudOccupancyTypeRepository _studOccupancyTypeRepository;
  private IAppLogger<UpdateStudOccupancyTypeCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public UpdateStudOccupancyTypeCommandHandler(IMapper mapper, IStudOccupancyTypeRepository studOccupancyTypeRepository
    , IAppLogger<UpdateStudOccupancyTypeCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._studOccupancyTypeRepository = studOccupancyTypeRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(UpdateStudOccupancyTypeCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var updateData = await _studOccupancyTypeRepository.GetByIdAsync(request.Id);

      if (updateData == null)
      {
        return await _responseService.ApiFailResponse($"Room category with ID {request.Id} not found.");
      }
      updateData.TypeName = request.TypeName;
      updateData.OrgId = request.OrgId;
      updateData.SiteId = request.SiteId;
      updateData.ModifiedOn = DateTime.Now;

      await _studOccupancyTypeRepository.UpdateAsync(updateData);

      return await _responseService.ApiSuccessResponse(null);
    }
    catch (Exception ex)
    {
      _logger.LogWarning($"Error saving StudOccupancyType: {ex.Message}", ex);
      if (ex.InnerException != null)
      {
        _logger.LogWarning($"Inner Exception: {ex.InnerException.Message}");
      }
      throw new BadRequestException($"Error at StudOccupancyType: {ex.Message}");
    }
  }

}