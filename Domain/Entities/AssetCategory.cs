﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

public class AssetCategory : BaseEntity
{
    public int OrgId { get; set; }

    public string Name { get; set; } = string.Empty;
}
