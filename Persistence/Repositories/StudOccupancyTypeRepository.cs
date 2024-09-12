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

public class StudOccupancyTypeRepository : GenericRepository<StudOccupancyType>, IStudOccupancyTypeRepository
{
  public StudOccupancyTypeRepository(HostelDatabaseContext context) : base(context)
  {

  }
}
