using System;
using System.Collections.Generic;
using System.Text;

namespace HelpCylinder.BusinessEntities
{
    public class Request
    {

        public long RequestId { get; set; }
		public string CallerName { get; set; }
		public string CallerMobileNo { get; set; }
		public string PatientName { get; set; }
		public string PatientAge { get; set; }
		public string PatientMobileNo { get; set; }
		public long AirSaturation { get; set; }
		public long O2Need { get; set; }
		public long HasEmptyCylinder { get; set; }
		public long NeedGuageMeter { get; set; }
		public long NeedMask { get; set; }
		public long NeedPanel { get; set; }
		public string Address { get; set; }
		public long Pincode { get; set; }
		public string CreatedDate { get; set; }
		public string ReferredByName { get; set; }
		public string ReferredByMobile { get; set; }
		public long NeedDoorDelivery { get; set; }
		public string IsActive { get; set; }
		public string Password { get; set; }
		public long RequestType { get; set; }
		public string BloodGroup { get; set; }
		public string PatientAdhaarPath { get; set; }
		public string DrPrescriptionPath { get; set; }
		public string Hrct { get; set; }
		public string Rtpcr { get; set; }
	}
}
