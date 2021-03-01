using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPI.API.Repositories
{
    public interface ICheckListRepository :IRepository<CheckList>
    {

    }
    public class CheckListRepository:Repository<CheckList>,ICheckListRepository
    {
        public CheckListRepository(ProjectManagementDbContext ctx):base(ctx)
        {

        }

        public override async Task<CheckList> Add(CheckList item)
        {
            if (item == null)
                return null;
            if (item.Title == null)
                return null;
            if (item.Description == null)
                return null;
            var checkList = new CheckList()
            {
                Title = item.Title,
                Description = item.Description,
            };
            _ctx.CheckLists.Add(checkList);
            await _ctx.SaveChangesAsync();
            return checkList;
        }

        public override async Task<IEnumerable<CheckList>> Get(bool asNoTracking = false)
        {
            var sourceCollection = _ctx.CheckLists.AsQueryable();
            if (asNoTracking)
                sourceCollection = sourceCollection.AsNoTracking();
            return await _ctx.CheckLists.ToListAsync();
        }

        public override async Task<CheckList> GetById(int id, bool asNoTracking = false)
        {
            var sourceCollection = _ctx.CheckLists.AsQueryable();
            if (asNoTracking)
                sourceCollection = sourceCollection.AsNoTracking();

            var item = await _ctx.CheckLists.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return null;
            return item;
        }

        public override Task<CheckList> RemoveById(int id)
        {
            throw new NotImplementedException();
        }
    }
    
}
