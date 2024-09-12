using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AssetCategory.Command.CreateAssetCategory;

public class CreateAssetCategoryCommand : IRequest<ApiResponse>
{
  public string Name { get; set; } = string.Empty;

  public int OrgId { get; set; }

}
