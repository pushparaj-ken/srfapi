using Application.Common;
using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RoomCategory.Queries.GetAllRoomCategories;

public class GetAllRoomCategoryHandler : IRequestHandler<GetAllRoomCategoryQuery, ApiResponse>
{
    private IMapper _mapper;
    private IRoomCategoryRepository _roomCategoryRepository;
    private IAppLogger<GetAllRoomCategoryHandler> _logger;

    private readonly APIResponseService _responseService;

    public GetAllRoomCategoryHandler(IMapper mapper, IRoomCategoryRepository roomCategoryRepository, IAppLogger<GetAllRoomCategoryHandler> logger, APIResponseService responseService)
    {
        this._mapper = mapper;
        this._roomCategoryRepository = roomCategoryRepository;
        this._logger = logger;
        this._responseService = responseService;
    }

    public async Task<ApiResponse> Handle(GetAllRoomCategoryQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var getAllData = await _roomCategoryRepository.GetAsync();
            if (getAllData == null)
            {
                return await _responseService.ApiFailResponse($"Room category not found.");
            }
            _logger.LogInformation("Room Categories were retrieved successfully");

            return await _responseService.ApiSuccessResponse(getAllData);
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
