using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Training
    {
        [Key]
        public int TrainingID { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan TimeTraining { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataTraining { get; set; }

        public string ApplicationUserID { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}
