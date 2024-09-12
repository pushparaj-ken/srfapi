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

namespace Application.Features.AssetCategory.Command.UpdateAssetCategory;


public class UpdateAssetCategoryCommandHandler : IRequestHandler<UpdateAssetCategoryCommand, ApiResponse>
{
  private IMapper _mapper;
  private IAssetCategoryRepository _assetCategoryRepository;
  private IAppLogger<UpdateAssetCategoryCommandHandler> _logger;

  private readonly APIResponseService _responseService;

  public UpdateAssetCategoryCommandHandler(IMapper mapper, IAssetCategoryRepository AssetCategoryRepository
    , IAppLogger<UpdateAssetCategoryCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._assetCategoryRepository = AssetCategoryRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(UpdateAssetCategoryCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var updateData = await _assetCategoryRepository.GetByIdAsync(request.Id);

      if (updateData == null)
      {
        return await _responseService.ApiFailResponse($"Asset category with ID {request.Id} not found.");
      }
      updateData.Name = request.Name;
      updateData.OrgId = request.OrgId;
      updateData.ModifiedOn = DateTime.Now;

      await _assetCategoryRepository.UpdateAsync(updateData);

      return await _responseService.ApiSuccessResponse(null);
    }
    catch (Exception ex)
    {
      _logger.LogWarning($"Error saving AssetCategory: {ex.Message}", ex);
      if (ex.InnerException != null)
      {
        _logger.LogWarning($"Inner Exception: {ex.InnerException.Message}");
      }
      throw new BadRequestException($"Error at AssetCategory: {ex.Message}");
    }
  }

}