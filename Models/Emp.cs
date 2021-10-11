using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StaffDeskWebApi.Models
{
    public class Emp
    {
        [Key]
        [Required]
        public int Empid { get; set; }

        [Required]

        public string EmpName { get; set; }

      
        

        public string Department { get; set; }



        public  string Image { get; set; }

        public DateTime DateofJoin { get; set; }


        [Required] 
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }




    }
}
