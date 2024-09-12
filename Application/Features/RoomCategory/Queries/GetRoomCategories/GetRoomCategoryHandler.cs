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

public class GetRoomCategoryHandler : IRequestHandler<GetRoomCategoryQuery, ApiResponse>
{
    private IMapper _mapper;
    private IRoomCategoryRepository _roomCategoryRepository;
    private IAppLogger<GetRoomCategoryHandler> _logger;
    private readonly APIResponseService _responseService;

    public GetRoomCategoryHandler(IMapper mapper, IRoomCategoryRepository roomCategoryRepository, IAppLogger<GetRoomCategoryHandler> logger, APIResponseService responseService)
    {
        this._mapper = mapper;
        this._roomCategoryRepository = roomCategoryRepository;
        this._logger = logger;
        this._responseService = responseService;
    }

    public async Task<ApiResponse> Handle(GetRoomCategoryQuery request,
       CancellationToken cancellationToken)
    {
        var getData = await _roomCategoryRepository.GetByIdAsync(request.Id);

        if (getData == null)
        {
            return await _responseService.ApiFailResponse($"Room category with ID {request.Id} not found.");
        }

        _logger.LogInformation($"Room Category with ID {request.Id} was retrieved successfully");

        return await _responseService.ApiSuccessResponse(getData);
    }
}
