using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DAL.Models
{
    public enum JobType { Accountant ,HR,FrontEnd_Developer, BackEnd__Developer}
    public class Empolyee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Display(Name = "National Id")]
        public string SSN { get; set; }

        public string Image { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date_hired { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public JobType Job { get; set; }
        public string User_ID { get; set; }

        [ForeignKey("User_ID")]
        public ApplicationUser User { get; set; }


    }
}
