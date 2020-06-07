using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPI.Model
{
    public class CheckList : IDbObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<CheckListItem> CheckListItems { get; set; }


        public IDbObject MakeNew()
        {
            return new CheckList { Title = Title, Description = Description };
        }

        public void UpdateFrom(IDbObject obj)
        {
            var q = obj as CheckList;
            Title = q.Title;
            Description = q.Description;
        }
    }
}
