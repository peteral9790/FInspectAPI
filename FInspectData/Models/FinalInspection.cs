using System;
namespace FInspectData.Models
{
    public class FinalInspection
    {
        public int Id { get; set; }
        public string TMSPartNumber { get; set; }
        public string MiStatusBarcode { get; set; }
        public DateTime DateInspected { get; set; }
        public int QuantityInspected { get; set; }
        public int QuantityAccepted { get; set; }
        public string HardwareRequired { get; set; }
        public string InspectionType { get; set; }
        public string MfgLocation { get; set; }
        public string InspectionLocation { get; set; }
        public virtual Inspector Inspector { get; set; }
        public virtual FinalInspectionUpload InspectionFiles { get; set; }
    }
}
