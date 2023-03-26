using System.ComponentModel.DataAnnotations;

namespace ClinicaDentariaFinalWork.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display (Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Locality")]
        public string Locality { get; set; }

        [Display(Name = "Zip-Code")]
        [DataType(DataType.PostalCode)]
        public virtual string ZipCode { get; set; }

        [Display(Name = "TaxPayer Number")]
        [StringLength(9, ErrorMessage = "It's necessary to enter 9 digits of the Taxpayer Number.", MinimumLength = 9)]
        public string TaxPayerNumber { get; set; }

        [Display (Name = "Health Insurance")]
        public bool HealthInsurance { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
