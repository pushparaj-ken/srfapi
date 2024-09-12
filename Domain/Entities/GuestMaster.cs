using Domain.Common;

namespace Domain;

public class GuestMaster : BaseEntity
{
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
}
