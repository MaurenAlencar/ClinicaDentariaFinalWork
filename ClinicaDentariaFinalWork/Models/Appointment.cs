using System.ComponentModel.DataAnnotations;

namespace ClinicaDentariaFinalWork.Models
{
    public class Appointment
    {
        public string ID { get; set; }

        [Display(Name = "Appointment number")]
        public int AppointmentNumber { get; set; }

        [Display(Name = "Appointment Date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Display(Name = "Appointment Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Time { get; set; }

        [Display(Name = "Clients")]
        public int ClientID { get; set; }
        public Client Client { get; set; }


        [Display (Name = "Doctor")]
        public int ProfessionalTeamID { get; set; }
        public ProfessionalTeam ProfessionalTeam { get; set; }

        public ICollection<ProfessionalTeam> ProfessionalTeams { get; set; }

        [Display (Name = "Observations")]
        public string Observations { get; set; }

        [Display ( Name = "Performed")]
        public bool Performed { get; set; }

    }
}
