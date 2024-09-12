using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

public class Lease : BaseEntity
{
    public Master? Master { get; set; }

    public int HostelId { get; set;  }

    public string ContractRemarks { get; set; } = string.Empty;
}
