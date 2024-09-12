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

public class StaffOccupancyTypeRepository : GenericRepository<StaffOccupancyType>, IStaffOccupancyTypeRepository
{
  public StaffOccupancyTypeRepository(HostelDatabaseContext context) : base(context)
  {

  }
}
