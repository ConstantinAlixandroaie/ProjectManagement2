﻿using ProjectManagementAPI.Data;
using ProjectManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPI.Controllers
{
    public abstract class BaseController<T> : ISiteController<T> where T : class, IDbObject
    {
        protected ProjectManagementDbContext _ctx;
        public BaseController(ProjectManagementDbContext ctx)
        {
            _ctx = ctx;
        }
        public virtual async Task<T> Add(T item)
        {
            if (item == null)
                return null;
            var newCli = item.MakeNew();
            _ctx.Add(newCli);
            await _ctx.SaveChangesAsync();
            return newCli as T;
        }

        public abstract Task<IEnumerable<T>> Get(bool asNoTracking = false);
        public abstract Task<T> GetById(int id, bool asNoTracking = false);
        public abstract Task<T> RemoveById(int id);
        public virtual async Task<bool> Remove(T item)
        {
            if (item == null)
                return false;

            return (await RemoveById(item.Id)) != null;
        }

        public virtual async Task<bool> Update(int id, T newData)
        {
            var itm = await GetById(id);
            if (itm == null)
                return false;

            itm.UpdateFrom(newData);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
