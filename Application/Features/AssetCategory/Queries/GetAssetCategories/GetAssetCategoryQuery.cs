using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AssetCategory.Queries.GetAllAssetCategories;

public class GetAssetCategoryQuery : IRequest<ApiResponse>
{
  public int Id { get; set; }
}