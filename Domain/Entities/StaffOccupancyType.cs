using Domain.Common;

namespace Domain;

public class StaffOccupancyType : BaseEntity
{
  public int OrgId { get; set; }

  public int SiteId { get; set; }

  public string TypeName { get; set; } = string.Empty;
}
