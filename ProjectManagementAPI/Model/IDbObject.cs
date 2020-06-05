using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPI.Model
{
    public interface IDbObject
    {
        int Id { get; }
        IDbObject MakeNew();
        void UpdateFrom(IDbObject obj);

    }
}
