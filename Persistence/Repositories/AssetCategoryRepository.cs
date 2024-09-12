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

public class AssetCategoryRepository : GenericRepository<AssetCategory>, IAssetCategoryRepository
{
    public AssetCategoryRepository(HostelDatabaseContext context) : base(context)
    {
        
    }

    public async Task<bool> IsAssetCategoryUnique(string name)
    {
        return await _context.Assets.AnyAsync(q => q.Name == name);
    }
}
