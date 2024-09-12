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

namespace Application.Features.RoomCategory.Command.UpdateRoomCategory;


public class UpdateRoomCategoryCommandHandler : IRequestHandler<UpdateRoomCategoryCommand, ApiResponse>
{
  private IMapper _mapper;
  private IRoomCategoryRepository _roomCategoryRepository;
  private IAppLogger<UpdateRoomCategoryCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public UpdateRoomCategoryCommandHandler(IMapper mapper, IRoomCategoryRepository roomCategoryRepository
    , IAppLogger<UpdateRoomCategoryCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._roomCategoryRepository = roomCategoryRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(UpdateRoomCategoryCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var updateData = await _roomCategoryRepository.GetByIdAsync(request.Id);

      if (updateData == null)
      {
        return await _responseService.ApiFailResponse($"Room category with ID {request.Id} not found.");
      }
      updateData.Name = request.Name;
      updateData.OrgId = request.OrgId;
      updateData.ModifiedOn = DateTime.Now;

      await _roomCategoryRepository.UpdateAsync(updateData);

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