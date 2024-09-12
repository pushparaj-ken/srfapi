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

public class GetAssetCategoryHandler : IRequestHandler<GetAssetCategoryQuery, ApiResponse>
{
  private IMapper _mapper;
  private IAssetCategoryRepository _assetCategoryRepository;
  private IAppLogger<GetAssetCategoryHandler> _logger;

  private readonly APIResponseService _responseService;

  public GetAssetCategoryHandler(IMapper mapper, IAssetCategoryRepository assetCategoryRepository, IAppLogger<GetAssetCategoryHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._assetCategoryRepository = assetCategoryRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(GetAssetCategoryQuery request, CancellationToken cancellationToken)
  {
    try
    {
      var getData = await _assetCategoryRepository.GetByIdAsync(request.Id);
      if (getData == null)
      {
        _logger.LogWarning($"AssetCategory with ID {request.Id} not found.");
        return await _responseService.ApiFailResponse($"Asset category with ID {request.Id} not found.");
      }

      _logger.LogInformation($"Asset Category with ID {request.Id} was retrieved successfully");

      return await _responseService.ApiSuccessResponse(getData);
    }
    catch (Exception ex)
    {
      _logger.LogWarning($"Error: {ex.Message}", ex);
      throw new BadRequestException($"Error: {ex}");
    }
  }
}