using FInspectData;
using FInspectData.Interfaces;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using FInspectData.Models;
using System.Data.Entity.Infrastructure;
using System;

namespace FInspectServices
{
    public class FinalInspectionService : IInspection
    {
        private FinalInspectionContext _db = new FinalInspectionContext();

        public void Add(FinalInspection newInspection)
        {
            if (newInspection != null)
            {
                _db.FinalInspections.Add(newInspection);
                try
                {
                    _db.Entry(newInspection.Inspector).State = EntityState.Unchanged;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                AttemptSave();
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public IEnumerable<FinalInspection> GetAll()
        {
            var history = _db.FinalInspections.Include(x => x.Inspector).Include(x => x.InspectionFiles);

            return history;
        }
        public void Update(FinalInspection inspection)
        {            

            if (inspection != null)
            {
                var record = _db.FinalInspections.Single(x => x.Id == inspection.Id);
                record.TMSPartNumber = inspection.TMSPartNumber;
                record.MiStatusBarcode = inspection.MiStatusBarcode;
                record.QuantityInspected = inspection.QuantityInspected;
                record.QuantityAccepted = inspection.QuantityAccepted;
                record.InspectionType = inspection.InspectionType;
                record.MfgLocation = inspection.MfgLocation;
                record.InspectionLocation = inspection.InspectionLocation;
                record.Inspector = inspection.Inspector;
                _db.Entry(record.Inspector).State = EntityState.Unchanged;
                _db.Entry(record).State = EntityState.Modified;          
            }
            else
            {
                throw new NullReferenceException();
            }
            AttemptSave();         
        }

        public FinalInspection GetById(int id)
        {
            return _db.FinalInspections.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var inspection = _db.FinalInspections.SingleOrDefault(x => x.Id == id);
            if (inspection != null)
            {
                _db.FinalInspections.Remove(inspection);
                AttemptSave();
            }
            else
            {
                throw new NullReferenceException();
            }
            
        } 

        public IEnumerable<FinalInspection> GetByInspectionType(string InspectionType)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<FinalInspection> GetByInspector(string Inspector_Id)
        {
            throw new System.NotImplementedException();
        }

        public FinalInspection GetByMiStatusBarcode(string MiStatusBarcode)
        {
            throw new System.NotImplementedException();
        }

        public string GetInspectorName(int id)
        {
            throw new System.NotImplementedException();
        }

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
    }
}
