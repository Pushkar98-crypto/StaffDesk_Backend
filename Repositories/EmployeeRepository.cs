using Microsoft.EntityFrameworkCore;
using StaffDeskWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffDeskWebApi.Repositories
{
    public class EmployeeRepository : IEmployee
    { 

        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public async Task<Emp> Create(Emp Emp)
        {
            _context.EmpTable.Add(Emp);
            await _context.SaveChangesAsync();
            return Emp;

        }

        public async Task Delete(int Empid)
        {
            var EmpToRemove = await _context.EmpTable.FindAsync(Empid);
            _context.EmpTable.Remove(EmpToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Emp>> Get()
        {
            return await _context.EmpTable.ToListAsync();
        }

        public  async Task<Emp> Get(int Empid)
        {
            return await _context.EmpTable.FindAsync(Empid);
            
        }

        public async Task Update(int id ,Emp Emp)
        {
            _context.Entry(Emp).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
        }

      
    } 
}
