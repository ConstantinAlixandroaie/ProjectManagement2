using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPI.Model
{
    public class Client : IDbObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public List<Project> Projects { get; set; }

        public IDbObject MakeNew()
        {
            return new Client {Name=Name,ImageUrl=ImageUrl };
        }

        public void UpdateFrom(IDbObject obj)
        {
            var q = obj as Client;
            Name = q.Name;
            ImageUrl = q.ImageUrl;
        }
    }
}

