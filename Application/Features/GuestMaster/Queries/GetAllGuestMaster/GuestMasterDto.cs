using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GuestMaster.Queries.GuestMaster;

public class GuestMasterDto
{
  public int Id { get; set; }

  public int OrgId { get; set; }

  public string Name { get; set; } = string.Empty;

  public string Addline1 { get; set; } = string.Empty;

  public string Addline2 { get; set; } = string.Empty;

  public string Addline3 { get; set; } = string.Empty;

  public string Addline4 { get; set; } = string.Empty;

  public string Phoneno1 { get; set; } = string.Empty;

  public string Phoneno2 { get; set; } = string.Empty;

  public int Pincode { get; set; }

  public string Remarks { get; set; } = string.Empty;

  public string? CreatedBy { get; set; }

  public DateTime CreatedOn { get; set; }

  public string? ModifiedBy { get; set; }

  public DateTime ModifiedOn { get; set; }
}
