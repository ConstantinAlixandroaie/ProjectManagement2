using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPI.Model
{
    public class Project : IDbObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int ClientId { get; set; }
        public string Owner { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Client Client { get; set; }


        public IDbObject MakeNew()
        {
            return new Project { Name = Name, Number = Number, ClientId = ClientId, Owner = Owner, StartDate = StartDate, EndDate = EndDate };
        }

        public void UpdateFrom(IDbObject obj)
        {
            var q = obj as Project;
            Name = q.Name;
            Number = q.Number;
            ClientId = q.ClientId;
            Owner = q.Owner;
            StartDate = q.StartDate;
            EndDate = q.EndDate;

        }
    }
}
