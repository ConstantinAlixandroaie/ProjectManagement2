using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ProjectManagementAPI.Model
{
    public class CheckListItem : IDbObject
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool StatusChecked { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
        public int CheckListId { get; set; }

        public CheckList CheckList { get; set; }


        public IDbObject MakeNew()
        {
            return new CheckListItem { Text = Text, StatusChecked = StatusChecked, DateCreated = DateCreated, DateEdited = DateEdited, CheckListId = CheckListId };
        }

        public void UpdateFrom(IDbObject obj)
        {
            var q = obj as CheckListItem;
            Text = q.Text;
            StatusChecked = q.StatusChecked;
            DateCreated = q.DateCreated;
            CheckListId = q.CheckListId;
        }
    }
}
