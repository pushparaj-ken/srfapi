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

namespace Application.Features.AssetCategory.Queries.GetAllAssetCategories;

public class GetAllAssetCategoryHandler : IRequestHandler<GetAllAssetCategoryQuery, ApiResponse>
{
    private IMapper _mapper;
    private IAssetCategoryRepository _assetCategoryRepository;
    private IAppLogger<GetAllAssetCategoryHandler> _logger;

    private readonly APIResponseService _responseService;

    public GetAllAssetCategoryHandler(IMapper mapper, IAssetCategoryRepository assetCategoryRepository, IAppLogger<GetAllAssetCategoryHandler> logger, APIResponseService responseService)
    {
        this._mapper = mapper;
        this._assetCategoryRepository = assetCategoryRepository;
        this._logger = logger;
        this._responseService = responseService;
    }

    public async Task<ApiResponse> Handle(GetAllAssetCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var getAllData = await _assetCategoryRepository.GetAsync();

        if (getAllData == null)
        {
            return await _responseService.ApiFailResponse("Asset category not found.");
        }

        _logger.LogInformation("Asset Categories were retrieved successfully");

        return await _responseService.ApiSuccessResponse(getAllData);
    }
}
