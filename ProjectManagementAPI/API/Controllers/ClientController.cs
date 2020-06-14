using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Controllers;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Model;

namespace ProjectManagementAPI.API.Controllers
{
    public interface IClientController:ISiteController<Client>
    {

    }
    public class ClientController : BaseController<Client>, IClientController
    {
        public ClientController(ProjectManagementDbContext ctx):base(ctx)
        {
                
        }

        public override Task<Client> Add(Client item)
        {
            return base.Add(item);
        }
        public override Task<IEnumerable<Client>> Get(bool asNoTracking = false)
        {
            throw new NotImplementedException();
        }

        public override Task<Client> GetById(int id, bool asNoTracking = false)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Update(int id, Client newData)
        {
            return base.Update(id, newData);
        }
        public override Task<bool> Remove(Client item)
        {
            return base.Remove(item);
        }
        public override Task<Client> RemoveById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
