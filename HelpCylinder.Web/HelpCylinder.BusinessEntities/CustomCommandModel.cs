using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpCylinder.BusinessEntities
{
    public class CustomCommandModel
    {
        public string ProcedureName { get; set; }
        public SqlParameter[] ParamArray { get; set; }

        public ProcedureType Type { get; set; }
    }

    public class CustomResponseModel<T>
    {
        public List<T> ResultDataTable { get; set; }

        public bool Status { get; set; }
    }

    public enum ProcedureType
    {
        Get,
        Post
    }
}
