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

namespace Application.Features.AssetCategory.Command.CreateAssetCategory;

public class CreateAssetCategoryCommandHandler : IRequestHandler<CreateAssetCategoryCommand, ApiResponse>
{
  private IMapper _mapper;
  private IAssetCategoryRepository _assetCategoryRepository;
  private IAppLogger<CreateAssetCategoryCommandHandler> _logger;
  private readonly APIResponseService _responseService;

  public CreateAssetCategoryCommandHandler(IMapper mapper, IAssetCategoryRepository assetCategoryRepository
      , IAppLogger<CreateAssetCategoryCommandHandler> logger, APIResponseService responseService)
  {
    this._mapper = mapper;
    this._assetCategoryRepository = assetCategoryRepository;
    this._logger = logger;
    this._responseService = responseService;
  }

  public async Task<ApiResponse> Handle(CreateAssetCategoryCommand request, CancellationToken cancellationToken)
  {

    try
    {
      var createData = new DomainAssetCategory
      {
        Name = request.Name,
        OrgId = request.OrgId,
        CreatedOn = DateTime.Now
      };
      await _assetCategoryRepository.CreateAsync(createData);

      return await _responseService.ApiSuccessResponse(createData);
    }
    catch (Exception ex)
    {
      _logger.LogWarning($"Error saving RoomCategory: {ex.Message}", ex);
      if (ex.InnerException != null)
      {
        _logger.LogWarning($"Inner Exception: {ex.InnerException.Message}");
      }
      throw new BadRequestException($"Error at AssetCategory: {ex.Message}");
    }
  }
}
