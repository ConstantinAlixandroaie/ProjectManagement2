using ProjectManagementAPI.Data;
using ProjectManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPI.API.Repositories
{
    public interface ICheckListItemRepository:IRepository<CheckListItem>
    {

    }
    public class CheckListItemRepository : Repository<CheckListItem>, ICheckListItemRepository
    {

        public CheckListItemRepository(ProjectManagementDbContext ctx):base(ctx)
        {

        }
        public override async Task<CheckListItem> Add(CheckListItem item)
        {
            if (item.CheckList == null)
                return null;
            if (string.IsNullOrEmpty(item.Text))
                return null;
            var checkListItem = new CheckListItem()
            {
                CheckList = item.CheckList,
                Text=item.Text,
                StatusChecked=item.StatusChecked,
                DateCreated=item.DateCreated,
                DateEdited=item.DateEdited,
                CheckListId=item.CheckListId,
            };
            _ctx.CheckListItems.Add(checkListItem);
            await _ctx.SaveChangesAsync();
            return checkListItem;

        }
        public override async Task<IEnumerable<CheckListItem>> Get(bool asNoTracking = false)
        {
            throw new NotImplementedException();
        }
        public override Task<CheckListItem> GetById(int id, bool asNoTracking = false)
        {
            throw new NotImplementedException();
        }
        public override Task<CheckListItem> RemoveById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
