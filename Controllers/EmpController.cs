using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffDeskWebApi.Models;
using StaffDeskWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffDeskWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    { 
        private readonly IEmployee _Employee;

        public EmpController(IEmployee Employee)
        {
            _Employee= Employee;
        }

        [HttpGet]
        public async Task<IEnumerable<Emp>> GetEmps()
        {
            return await _Employee.Get();

        }

      
        [HttpGet]
        [Route("{Empid}")]

        public async Task<ActionResult<Emp>>GetEmps(int Empid)
        {
            Emp employee = await _Employee.Get(Empid);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPost]
        public  async Task<ActionResult<Emp>>PostEmps([FromBody] Emp Emp)
        {
            var newEmp = await _Employee.Create(Emp);
            return CreatedAtAction(nameof(GetEmps), new { id = newEmp.Empid }, newEmp);
        }

        [HttpPut]
        [Route("{Empid}")]

        public async Task<ActionResult>PutEmps(int Empid, [FromBody] Emp Emp)
        {
            if(Empid != Emp.Empid)
            {
                return BadRequest();
            }
            await _Employee.Update(Empid,Emp);

            return NoContent();

        }

        [HttpDelete]

        public async Task<ActionResult> Delete (int Empid)
        {
            var EmpToRemove = await _Employee.Get(Empid);
            if (EmpToRemove == null)
                return NotFound();

            await _Employee.Delete(EmpToRemove.Empid);
            return NoContent();
        }
    }
}
