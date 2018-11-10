using FInspectAPI.Models;
using FInspectServices;
using System;
using System.Linq;
using System.Web.Mvc;

namespace FInspectMVC.Controllers
{
    public class InspectionController : Controller
    {
        public readonly FinalInspectionService  _inspectionService= new FinalInspectionService();

        // GET: Inspection
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewInspections()
        {
            //System.Threading.Thread.Sleep(2000);
            try
            {
                var InspectionHistory = _inspectionService.GetAll().Select(result => new FinalInspection
                {
                    Id = result.Id,
                    TMSPartNumber = result.TMSPartNumber,
                    MiStatusBarcode = result.MiStatusBarcode,
                    DateInspected = result.DateInspected.ToString("MM/dd/yyyy"),
                    QuantityInspected = result.QuantityInspected,
                    QuantityAccepted = result.QuantityAccepted,
                    InspectionType = result.InspectionType,
                    MfgLocation = result.MfgLocation,
                    InspectionLocation = result.InspectionLocation,
                    InspectorName = result.Inspector.FirstName + " " + result.Inspector.LastName,
                    EmployeeId = result.Inspector.EmployeeId
                    //FinalInspectionUploads = ConvertAPIUploads(result.FinalInspectionUploads)
                });
                return View(InspectionHistory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}