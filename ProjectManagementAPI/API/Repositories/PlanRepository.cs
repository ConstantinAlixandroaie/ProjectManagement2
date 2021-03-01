using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.API.Repositories;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagementAPI.API.Repositories
{
    public interface IPlansRepository:IRepository<Plan>
    {

    }
    public class PlanRepository : Repository<Plan>, IPlansRepository
    {
        public PlanRepository(ProjectManagementDbContext ctx):base(ctx)
        {

        }
        public override async Task<Plan> Add(Plan item)
        {
            if (item == null)
                return null;
            if (item.Name == null)
                return null;
            var plan = new Plan()
            {
                Name = item.Name,

            };
            _ctx.Plans.Add(plan);
            await _ctx.SaveChangesAsync();
            return plan;
        }
        public override async Task<IEnumerable<Plan>> Get(bool asNoTracking = false)
        {
            var sourceCollection = _ctx.Plans.AsQueryable();
            if (asNoTracking)
                sourceCollection = sourceCollection.AsNoTracking();
            return await _ctx.Plans.ToListAsync();
        }

        public override async Task<Plan> GetById(int id, bool asNoTracking = false)
        {
            var sourceCollection = _ctx.Plans.AsQueryable();
            if (asNoTracking)
                sourceCollection = sourceCollection.AsNoTracking();

            var item = await _ctx.Plans.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return null;
            return item;
        }

        public override async Task<bool> Update(int id, Plan newData)
        {
            var item = await _ctx.Plans.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return false;
            if(newData.Name!=null)
            {
                item.Name = newData.Name;
            }
            if(newData.Project!=null)
            {
                item.Project = newData.Project;
            }
            await _ctx.SaveChangesAsync();
            return true;
        }
        public override async Task<Plan> RemoveById(int id)
        {
            var item = await _ctx.Plans.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return null;
            _ctx.Plans.Remove(item);
            await _ctx.SaveChangesAsync();
            return item;

        }
    }
}
