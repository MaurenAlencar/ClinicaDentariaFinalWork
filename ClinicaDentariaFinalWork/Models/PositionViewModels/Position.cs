using System.ComponentModel.DataAnnotations;

namespace ClinicaDentariaFinalWork.Models.PositionViewModels
{
    public class Position
    {

        public int ID { get; set; }
        public string Name { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Display(Name = "Available")]
        public bool Available { get; set; }
        [Display(Name = "Teams")]
        public ICollection<ProfessionalTeam>? ProfessionalTeams { get; set; }

    }
}
