using FInspectData.Models;

namespace FInspectData.Interfaces
{
    public interface IFinalInspectionUploads
    {
        FinalInspectionUpload GetInspectionFiles(int id);
    }
}
