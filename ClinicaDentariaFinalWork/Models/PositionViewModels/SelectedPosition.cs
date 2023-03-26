namespace ClinicaDentariaFinalWork.Models.PositionViewModels
{
    public class SelectedPosition
    {
        public int  ID { get; set; }
        public int PositionID { get; set; }

        public string NamePosition { get; set; }

        //public List<SelectedPosition> PositionList()
        //{
        //    return new List<SelectedPosition>
        //        {
        //            new SelectedPosition { PositionID = 0, NamePosition = "Assistente"},
        //            new SelectedPosition { PositionID = 1, NamePosition = "Médico"},
        //            new SelectedPosition { PositionID = 2, NamePosition = "Recepcionista"}

        //         };
        //}

        public string PositionSelected { get; set; }
        public bool Selected { get; set; }

        
    }
}
