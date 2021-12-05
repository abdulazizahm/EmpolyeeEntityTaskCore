using Microsoft.AspNetCore.Http;
using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
    public class EmpolyeeViewModel
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
        public JobType Job { get; set; }
        [Required]
        public decimal Salary { get; set; }
        

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date_hired { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile FormFileImage { get; set; }
        public string User_ID { get; set; }

        [ForeignKey("User_ID")]
        public ApplicationUser User { get; set; }

    }
}
