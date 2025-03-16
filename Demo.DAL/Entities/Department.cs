using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entities
{
    public class Department :BaseEntity
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="department name is required")]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "please enter department code within 1 and 100")]
        public int Code  { get; set; }

        [Required(ErrorMessage = "department date of creation is required")]

        [DisplayName("Date Of Creation")]
        public DateTime DateOfCreation { get; set; }
    }
}
