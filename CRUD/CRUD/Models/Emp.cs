using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class Emp
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        [Required]
        public int State { get; set; }
        [Required]
        public int City { get; set; }
        public string Pin { get; set; }
    }
}