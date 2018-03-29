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
        public TimeSpan Time { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string CoachID { get; set; }
        public string PlayerID { get; set; }

        public ApplicationUser Coach { get; set; }
        public ApplicationUser Player { get; set; }
    }
}
