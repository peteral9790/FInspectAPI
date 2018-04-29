using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace FInspectData.Models
{
    public class FinalInspectionUpload
    {
        [Key]
        public int Id { get; set; }
        public string Attachment { get; set; }
    }
}
