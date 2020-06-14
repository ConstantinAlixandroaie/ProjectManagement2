using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Controllers;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Model;

namespace ProjectManagementAPI.API.Controllers
{
    public interface IClientController : ISiteController<Client>
    {

    }
    public class ClientController : BaseController<Client>, IClientController
    {
        public ClientController(ProjectManagementDbContext ctx) : base(ctx)
        {

        }

        public override async Task<Client> Add(Client item)
        {
            if (item == null)
                return null;
            if (item.Name == null)
                return null;
            if (item.ImageUrl == null)
                return null;
            var client = new Client()
            {
                Name = item.Name,
                ImageUrl = item.ImageUrl,
            };
            _ctx.Clients.Add(client);
            await _ctx.SaveChangesAsync();
            return client;
        }
        public override async Task<IEnumerable<Client>> Get(bool asNoTracking = false)
        {
            var sourceCollection = _ctx.Clients.AsQueryable();
            if (asNoTracking)
                sourceCollection = sourceCollection.AsNoTracking();
            return await _ctx.Clients.ToListAsync();
        }

        public override async Task<Client> GetById(int id, bool asNoTracking = false)
        {
            var sourceCollection = _ctx.Clients.AsQueryable();
            if (asNoTracking)
                sourceCollection = sourceCollection.AsNoTracking();

            var item = await _ctx.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return null;

            return item;
        }

        public override async Task<bool> Update(int id, Client newData)
        {
            var item = await GetById(id);
            if (item == null)
                return false;

            if (newData.ImageUrl != null)
            {
                item.ImageUrl = newData.ImageUrl;
            }
            if (newData.Name != null)
            {
                item.Name = newData.Name;
            }
            await _ctx.SaveChangesAsync();
            return true;
        }
        public override async Task<Client> RemoveById(int id)
        {
            var item = await _ctx.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return null;

            _ctx.Clients.Remove(item);
            await _ctx.SaveChangesAsync();
            return item;
        }
    }
}
