using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPI.Model
{
    public class Plan : IDbObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Project Project { get; set; }

        public IDbObject MakeNew()
        {
            return new Plan { Name = Name, Id  = Id };
        }

        public void UpdateFrom(IDbObject obj)
        {
            var q = obj as Plan;
            Name = q.Name;
            Id = q.Id;
        }
    }
}
