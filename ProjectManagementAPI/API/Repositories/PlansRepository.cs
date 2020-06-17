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
    public class PlansRepository : Repository<Plan>, IPlansRepository
    {
        public PlansRepository(ProjectManagementDbContext ctx):base(ctx)
        {

        }
        public override Task<IEnumerable<Plan>> Get(bool asNoTracking = false)
        {
            throw new NotImplementedException();
        }

        public override Task<Plan> GetById(int id, bool asNoTracking = false)
        {
            throw new NotImplementedException();
        }

        public override Task<Plan> RemoveById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
