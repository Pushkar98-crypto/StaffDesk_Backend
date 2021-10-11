using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffDeskWebApi.Models;

namespace StaffDeskWebApi.Repositories
{
   public interface IEmployee
    {
        Task<IEnumerable<Emp>> Get();

        Task<Emp> Get(int Empid);  

        Task<Emp> Create(Emp Emp);

        Task Update(int id, Emp Emp);

        Task Delete(int Empid);
    }
}
