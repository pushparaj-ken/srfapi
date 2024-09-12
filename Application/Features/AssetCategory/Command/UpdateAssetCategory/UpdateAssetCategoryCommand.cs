using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AssetCategory.Command.UpdateAssetCategory;

public class UpdateAssetCategoryCommand : IRequest<ApiResponse>
{
  public int Id { get; set; }

  public string Name { get; set; } = string.Empty;

  public int OrgId { get; set; }
}