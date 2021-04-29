using System;
using System.Collections.Generic;
using System.Text;

namespace HelpCylinder.BusinessEntities
{
    public class Cylinder
    {
        public int CylinderId { get; set; }

		public string Code { get; set; }
		public string CylinderName { get; set; }
		public bool IsActive { get; set; }
		public string CreatedDate { get; set; }
		public int Status { get; set; }
		public string Capacity { get; set; }
		public string PAmt { get; set; }
		public string OnReturnAmt { get; set; }
		public string CautionDeposit { get; set; }
		public string Manufactuer { get; set; }
		public string MAddress { get; set; }
		public string MContactName { get; set; }
		public string MMobile { get; set; }
	}
}
