using FInspectAPI.Models;
using FInspectServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FInspectAPI.Controllers
{
    public class FinalInspectionController : ApiController
    {
        private readonly FinalInspectionService _InspectionService = new FinalInspectionService();
        private readonly InspectorService _InspectorService = new InspectorService();
        private readonly FinalInspectionUploadService _FileUploadService = new FinalInspectionUploadService();

        [HttpGet()]
        [ActionName("GetInspections")]
        public IHttpActionResult GetInspections()
        {
            //System.Threading.Thread.Sleep(2000);
            try
            {
                var InspectionHistory = _InspectionService.GetAll().Select(result => new FinalInspection
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
                    EmployeeId = result.Inspector.EmployeeId,
                    InspectionFiles = result.InspectionFiles
                });
                if (InspectionHistory != null)
                {
                    return Ok(InspectionHistory);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost()]
        [ActionName("AddNewInspection")]
        public IHttpActionResult AddNewInspection(FinalInspection newInspection)
        {
            if(ModelState.IsValid)
            {
                var inspector = new FInspectData.Models.Inspector();
                inspector = _InspectorService.GetByEmployeeId(newInspection.EmployeeId);
                var Record = new FInspectData.Models.FinalInspection()
                {
                    TMSPartNumber = newInspection.TMSPartNumber,
                    MiStatusBarcode = newInspection.MiStatusBarcode,
                    DateInspected = DateTime.Now,
                    QuantityAccepted = newInspection.QuantityAccepted,
                    QuantityInspected = newInspection.QuantityInspected,
                    MfgLocation = newInspection.MfgLocation,
                    InspectionLocation = newInspection.InspectionLocation,
                    InspectionType = newInspection.InspectionType,
                    Inspector = inspector,
                    InspectionFiles = newInspection.InspectionFiles
                };
                _InspectionService.Add(Record);
                return Ok(Record);
            }
            else
            {
                return BadRequest("Model state not valid. " + ModelState);
            }            
        }

        [HttpDelete()]
        [ActionName("DeleteInspection")]
        public IHttpActionResult DeleteInspection(int id)
        {
            if (id != 0)
            {
                _InspectionService.Delete(id);
                return Ok(id);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut()]
        [ActionName("UpdateInspection")]
        public IHttpActionResult UpdateInspection(int? id, FinalInspection inspection)
        {
            if (id != inspection.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var newDetails = new FInspectData.Models.FinalInspection()
                {
                    //Id = inspection.Id ?? default(int),
                    Id = inspection.Id.GetValueOrDefault(),
                    TMSPartNumber = inspection.TMSPartNumber,
                    MiStatusBarcode = inspection.MiStatusBarcode,
                    QuantityInspected = inspection.QuantityInspected,
                    QuantityAccepted = inspection.QuantityAccepted,
                    MfgLocation = inspection.MfgLocation,
                    InspectionLocation = inspection.InspectionLocation,
                    InspectionType = inspection.InspectionType,
                    Inspector = _InspectorService.GetByEmployeeId(inspection.EmployeeId),
                    InspectionFiles = inspection.InspectionFiles
                };
                _InspectionService.Update(newDetails);
                return Ok(System.Net.HttpStatusCode.NoContent);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        [HttpPost()]
        [ActionName("UploadInspectionFiles")]
        public IHttpActionResult UploadInspectionFiles()
        {
            int i = 0;
            int j = 1;
            int cntSuccess = 0;
            var uploadedFileNames = new List<string>();
            string result = string.Empty;

            HttpResponseMessage response = new HttpResponseMessage();

            var httpRequest = HttpContext.Current.Request;
            if(httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[i];
                    var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + postedFile.FileName);
                    try
                    {
                        postedFile.SaveAs(filePath);
                        uploadedFileNames.Add(httpRequest.Files[i].FileName);
                        cntSuccess++;
                    }
                    catch (Exception ex)
                    {
                        return BadRequest("Unable to upload files! " + ex.Message);
                    }

                    i++;
                }
            }

            return Json(uploadedFileNames);

            //result = cntSuccess.ToString() + " files uploaded successfully. <br/>";
            //result += "<ul>";

            //foreach (var f in uploadedFileNames)
            //{
            //    result += "<li id=Upload_" + j + "\">" + f + "</li>";
            //    j++;
            //}

            //result += "</ul>";
            //return Json(result);
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}