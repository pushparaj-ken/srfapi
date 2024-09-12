using Domain.Common;

namespace Domain;

public class StudOccupancyType : BaseEntity
{
  public int OrgId { get; set; }

  public int SiteId { get; set; }

  public string TypeName { get; set; } = string.Empty;
}
