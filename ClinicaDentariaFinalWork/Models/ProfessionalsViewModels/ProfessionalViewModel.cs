using ClinicaDentariaFinalWork.Models.PositionViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using NuGet.Configuration;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ClinicaDentariaFinalWork.Models.ProfessionalsViewModels
{
    public class ProfessionalViewModel
    {
       
        public int ID { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; }


        [Display(Name = "Birthday")]
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



        [Display(Name = "Position")]

        public int PositionID { get; set; }
        public int[] PositionIDs { get; set; } = Array.Empty<int>();
       // public List<SelectablePositionViewModel> SelectablePositions { get; set; }



        [Display(Name = "Specialty")]

        public int SpecialtyID { get; set; }
        public int[] SpecialtyIDs { get; set; } = Array.Empty<int>();
        //public List<SelectableSpecialtyViewModel> SelectableSpecialties { get; set; }




        //esta funicionando
        // [Display(Name = "position")]


        //public int PositionID { get; set; }

        //public string Nameposition { get; set; }
        //public Positions OptionsPosition { get; set; }






    }




    //public enum Positions
    //{
    //    Assistente,
    //    Médico,
    //    Recepcionista
    //}



}
