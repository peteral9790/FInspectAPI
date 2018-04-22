using System.ComponentModel.DataAnnotations;

namespace FInspectAPI.Models
{
    public class FinalInspectionUpload
    {
        public int Id { get; set; }
        public string Attachment1 { get; set; }
        public string Attachment2 { get; set; }
        public string Attachment3 { get; set; }
        public string Attachment4 { get; set; }
        public string Attachment5 { get; set; }
    }
}