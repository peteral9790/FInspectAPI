﻿using System;
using System.Collections.Generic;

namespace FInspectAPI.Models
{
    public class FinalInspection
    {
        public int? Id { get; set; }
        public string TMSPartNumber { get; set; }
        public string MiStatusBarcode { get; set; }
        public string DateInspected { get; set; }
        public int QuantityInspected { get; set; }
        public int QuantityAccepted { get; set; }
        public string MfgLocation { get; set; }
        public string InspectionLocation { get; set; }
        public string InspectionType { get; set; }
        public string InspectorName { get; set; }
        public int EmployeeId { get; set; }
        public List<string> FinalInspectionUploads { get; set; }
    }
}