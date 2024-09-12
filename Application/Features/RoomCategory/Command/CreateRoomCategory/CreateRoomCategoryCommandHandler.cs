using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using DomainRoomCategory = Domain.RoomCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;

namespace Application.Features.RoomCategory.Command.CreateRoomCategory;


public class CreateRoomCategoryCommandHandler : IRequestHandler<CreateRoomCategoryCommand, ApiResponse>
{
  private IMapper _mapper;
  private IRoomCategoryRepository _roomCategoryRepository;
  private IAppLogger<CreateRoomCategoryCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public CreateRoomCategoryCommandHandler(IMapper mapper, IRoomCategoryRepository roomCategoryRepository
    , IAppLogger<CreateRoomCategoryCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._roomCategoryRepository = roomCategoryRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(CreateRoomCategoryCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var createData = new DomainRoomCategory
      {
        Name = request.Name,
        OrgId = request.OrgId,
        CreatedOn = DateTime.Now
      };
      await _roomCategoryRepository.CreateAsync(createData);

      return await _responseService.ApiSuccessResponse(createData);
    }
    catch (Exception ex)
    {
      _logger.LogWarning($"Error saving RoomCategory: {ex.Message}", ex);
      if (ex.InnerException != null)
      {
        _logger.LogWarning($"Inner Exception: {ex.InnerException.Message}");
      }
      throw new BadRequestException($"Error at RoomCategory: {ex.Message}");
    }
  }

}