using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Model;
using ProjectManagementAPI.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagementAPI.API.Repositories
{
    public interface IProjectsRepository:IRepository<Project>
    {

    }
    public class ProjectRepository : Repository<Project>,IProjectsRepository
    {
        public ProjectRepository(ProjectManagementDbContext ctx) : base(ctx)
        {

        }
        public override async Task<Project> Add(Project item)
        {
            if (item == null)
            {
                return null;
            }
            if (item.Name == null)
            {
                return null;
            }
            if (item.Number == null)
            {
                return null;
            }
            if (item.Owner == null)
            {
                return null;
            }
            if (item.StartDate == null)
            {
                return null;
            }
            if (item.EndDate == null)
            {
                return null;
            }
            var project = new Project()
            {
                Name = item.Name,
                Number = item.Number,
                Owner=item.Owner,
                StartDate=item.StartDate,
                EndDate=item.EndDate,
                ClientId=item.ClientId,
            };
            _ctx.Projects.Add(project);
            await _ctx.SaveChangesAsync();
            return project;

        }
        public override async Task<IEnumerable<Project>> Get(bool asNoTracking = false)
        {
            var sourceCollection = _ctx.Projects.AsQueryable();
            if (asNoTracking)
                sourceCollection = sourceCollection.AsNoTracking();
            return await _ctx.Projects.ToListAsync();
        }

        public override async Task<Project> GetById(int id, bool asNoTracking = false)
        {
            var sourceCollection = _ctx.Projects.AsQueryable();
            if (asNoTracking)
                sourceCollection = sourceCollection.AsNoTracking();
            var item = await _ctx.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return null;

            return item;
        }

        public override async Task<Project> RemoveById(int id)
        {
            var item = await _ctx.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return null;

            _ctx.Projects.Remove(item);
            await _ctx.SaveChangesAsync();
            return item;
        }
        public override async Task<bool> Update(int id, Project newData)
        {
            var item = await _ctx.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return false;
            if (newData.Name != null)
            {
                item.Name = newData.Name;
            }
            if (newData.Number != null)
            {
                item.Number = newData.Number;
            }
            if (newData.Owner != null)
            {
                item.Owner = newData.Owner;
            }
            if (newData.StartDate != null)
            {
                item.StartDate = newData.StartDate;
            }
            if (newData.EndDate != null)
            {
                item.EndDate = newData.EndDate;
            }
            if (newData.Client != null)
            {
                item.Client = newData.Client;
            }
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
