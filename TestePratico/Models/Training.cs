using System;
using System.ComponentModel.DataAnnotations;

namespace TestePratico.Models
{
    //Classe para gerenciar Training no banco de dados
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
