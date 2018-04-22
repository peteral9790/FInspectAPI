using FInspectData;
using FInspectData.Interfaces;
using System;
using System.Linq;
using FInspectData.Models;

namespace FInspectServices
{
    public class FinalInspectionUploadService : IFinalInspectionUploads
    {
        private FinalInspectionContext _db = new FinalInspectionContext();

        public void AttemptSave()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FinalInspectionUpload GetInspectionFiles(int id)
        {
            return _db.FinalInspectionUploads.FirstOrDefault(x => x.Id == id);
        }
    }
}
