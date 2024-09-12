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

namespace Application.Features.StudOccupancyType.Command.CreateStudOccupancyType;


public class CreateStudOccupancyTypeCommandHandler : IRequestHandler<CreateStudOccupancyTypeCommand, ApiResponse>
{
  private IMapper _mapper;
  private IStudOccupancyTypeRepository _studOccupancyTypeRepository;
  private IAppLogger<CreateStudOccupancyTypeCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public CreateStudOccupancyTypeCommandHandler(IMapper mapper, IStudOccupancyTypeRepository studOccupancyTypeRepository
    , IAppLogger<CreateStudOccupancyTypeCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._studOccupancyTypeRepository = studOccupancyTypeRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(CreateStudOccupancyTypeCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var createData = new DomainStudOccupancyType
      {
        TypeName = request.TypeName,
        OrgId = request.OrgId,
        SiteId = request.SiteId,
        CreatedOn = DateTime.Now
      };
      await _studOccupancyTypeRepository.CreateAsync(createData);

      return await _responseService.ApiSuccessResponse(createData);
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