using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudOccupancyType.Queries.StudOccupancyType;

public class StudOccupancyTypeDto
{
  public int Id { get; set; }

  public int OrgId { get; set; }

  public int SiteId { get; set; }

  public string TypeName { get; set; } = string.Empty;

  public string? CreatedBy { get; set; }

  public DateTime CreatedOn { get; set; }

  public string? ModifiedBy { get; set; }

  public DateTime ModifiedOn { get; set; }
}
