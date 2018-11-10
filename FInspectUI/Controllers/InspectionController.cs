using FInspectServices;
using FInspectUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace FInspectUI.Controllers
{
    public class InspectionController : Controller
    {
        private readonly FinalInspectionService _inspectionContext = new FinalInspectionService();

        // GET: Inspection
        public ActionResult ViewInspections()
        {
            var inspectionHistory = _inspectionContext.GetAll().Select(result => new Inspection
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
                //,
                //FinalInspectionUploads = ConvertAPIUploads(result.FinalInspectionUploads)
            });

            return View(inspectionHistory);
        }

        // GET: Inspection
        public ActionResult Index()
        {
            return View();
        }
    }
}