using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaDentariaFinalWork.Models
{
    public class Invoice
    {
        public int ID { get; set; }

        [Display (Name = "Invoice Number")]
        public int InvoiceNumber { get; set; }

        [Display (Name = "Description procedure performed")]
        public string Procedure { get; set; }


        [Display (Name = "Final Value")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Range(0.00, 999999999.99, ErrorMessage = "RangeErrorMessage")]
        [DataType(DataType.Currency)]
        public int Value { get; set; }

        [Display(Name = "Clients")]
        public int ClientID { get; set; }
        public Client Client { get; set; }

        public ICollection<Client> Clients { get; set; }

        [Display (Name = "Payment status")]
        public bool Status { get; set; }

        [Display (Name = "Appointment")]
        public int AppointmentID { get; set; }
        public Appointment Appointment { get; set; } 


    }

}
