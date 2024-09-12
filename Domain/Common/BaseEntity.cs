﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; } = DateTime.Now;

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; } = DateTime.Now;
    }
}
