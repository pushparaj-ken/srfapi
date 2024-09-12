using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using DomainAssetCategory = Domain.AssetCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;

namespace Application.Features.AssetCategory.Command.DeleteAssetCategory;


public class DeleteAssetCategoryCommandHandler : IRequestHandler<DeleteAssetCategoryCommand, ApiResponse>
{
  private IMapper _mapper;
  private IAssetCategoryRepository _assetCategoryRepository;
  private IAppLogger<DeleteAssetCategoryCommandHandler> _logger;

  private readonly APIResponseService _responseService;

  public DeleteAssetCategoryCommandHandler(IMapper mapper, IAssetCategoryRepository roomCategoryRepository
    , IAppLogger<DeleteAssetCategoryCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._assetCategoryRepository = roomCategoryRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(DeleteAssetCategoryCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var deleteData = await _assetCategoryRepository.GetByIdAsync(request.Id);

      if (deleteData == null)
      {
        return await _responseService.ApiFailResponse($"Asset category with ID {request.Id} not found.");
      }

      await _assetCategoryRepository.DeleteASync(deleteData);

      return await _responseService.ApiSuccessResponse(null);
    }
    catch (Exception ex)
    {
      _logger.LogWarning($"Error saving AssetCategory: {ex.Message}", ex);
      if (ex.InnerException != null)
      {
        _logger.LogWarning($"Inner Exception: {ex.InnerException.Message}");
      }
      throw;
    }
  }

}