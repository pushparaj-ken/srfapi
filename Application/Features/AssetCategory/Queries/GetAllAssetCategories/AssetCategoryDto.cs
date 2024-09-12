using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AssetCategory.Queries.GetAllAssetCategories;

public class AssetCategoryDto
{
    public int Id { get; set; }

    public int OrgId { get; set; }

    public string Name { get; set; } = string.Empty;
}
