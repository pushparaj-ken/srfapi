using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class HostelMasterRepository : GenericRepository<HostelMaster>, IHostelMasterRepository
{
  public HostelMasterRepository(HostelDatabaseContext context) : base(context)
  {

  }
}
