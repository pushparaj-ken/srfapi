using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RoomCategory.Queries.GetAllRoomCategories;

public class RoomCategoryDto
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string OrgId { get; set; }
  public string? CreatedBy { get; set; }
  public DateTime CreatedOn { get; set; }
  public string? ModifiedBy { get; set; }
  public DateTime ModifiedOn { get; set; }
}
