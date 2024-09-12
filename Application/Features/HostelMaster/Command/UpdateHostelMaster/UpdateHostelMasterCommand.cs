using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HostelMaster.Command.UpdateHostelMaster;

public class UpdateHostelMasterCommand : IRequest<ApiResponse>
{
  public int Id { get; set; }

  public int OrgId { get; set; }

  public int SiteId { get; set; }

  public string No { get; set; } = string.Empty;

  public string Name { get; set; } = string.Empty;

  public string Owner { get; set; } = string.Empty;

  public string OwnerNatid { get; set; } = string.Empty;

  public string Addline1 { get; set; } = string.Empty;

  public string Addline2 { get; set; } = string.Empty;

  public string Addline3 { get; set; } = string.Empty;

  public string Addline4 { get; set; } = string.Empty;

  public string Phoneno1 { get; set; } = string.Empty;

  public string Phoneno2 { get; set; } = string.Empty;

  public string Phoneno3 { get; set; } = string.Empty;

  public int Zipcode { get; set; }

  public string EmailId { get; set; } = string.Empty;

  public string AddressLink { get; set; } = string.Empty;

  public DateTime? NextReneWaldate { get; set; }

  public string CurWardenName { get; set; } = string.Empty;

  public string WardenContactNo { get; set; } = string.Empty;

  public string WardenMailId { get; set; } = string.Empty;

  public string EbNo { get; set; } = string.Empty;

  public string WaterNo { get; set; } = string.Empty;

  public string ZoneNo { get; set; } = string.Empty;

  public string StreetNo { get; set; } = string.Empty;

  public int Capacity { get; set; }

  public string AppliCableSelGrade { get; set; } = string.Empty;

  public string AppliCableSelForms { get; set; } = string.Empty;
}