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

namespace Application.Features.RoomCategory.Command.DeleteRoomCategory;


public class DeleteRoomCategoryCommandHandler : IRequestHandler<DeleteRoomCategoryCommand, ApiResponse>
{
  private IMapper _mapper;
  private IRoomCategoryRepository _roomCategoryRepository;
  private IAppLogger<DeleteRoomCategoryCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public DeleteRoomCategoryCommandHandler(IMapper mapper, IRoomCategoryRepository roomCategoryRepository
    , IAppLogger<DeleteRoomCategoryCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._roomCategoryRepository = roomCategoryRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(DeleteRoomCategoryCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var DeleteData = await _roomCategoryRepository.GetByIdAsync(request.Id);

      if (DeleteData == null)
      {
        return await _responseService.ApiFailResponse($"Room category with ID {request.Id} not found.");
      }

      await _roomCategoryRepository.DeleteASync(DeleteData);

      return await _responseService.ApiSuccessResponse(null);
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