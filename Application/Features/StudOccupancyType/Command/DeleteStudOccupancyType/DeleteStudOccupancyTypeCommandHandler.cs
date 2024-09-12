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

namespace Application.Features.StudOccupancyType.Command.DeleteStudOccupancyType;


public class DeleteStudOccupancyTypeCommandHandler : IRequestHandler<DeleteStudOccupancyTypeCommand, ApiResponse>
{
  private IMapper _mapper;
  private IStudOccupancyTypeRepository _studOccupancyTypeRepository;
  private IAppLogger<DeleteStudOccupancyTypeCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public DeleteStudOccupancyTypeCommandHandler(IMapper mapper, IStudOccupancyTypeRepository studOccupancyTypeRepository
    , IAppLogger<DeleteStudOccupancyTypeCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._studOccupancyTypeRepository = studOccupancyTypeRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(DeleteStudOccupancyTypeCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var DeleteData = await _studOccupancyTypeRepository.GetByIdAsync(request.Id);

      if (DeleteData == null)
      {
        return await _responseService.ApiFailResponse($"Room category with ID {request.Id} not found.");
      }

      await _studOccupancyTypeRepository.DeleteASync(DeleteData);

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