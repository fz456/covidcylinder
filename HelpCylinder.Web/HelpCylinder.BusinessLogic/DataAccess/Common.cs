using HelpCylinder.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HelpCylinder.BusinessLogic.DataAccess
{
    public class Common
    {
        private SqlConnection _objSqlConnection;
        private ConnectionHandler _objConnectionHandler;
        private SqlCommand _objSqlCommand;
        private Common _objCommon;

        /// <summary>
        /// Faizan Syed -
        /// Create datbase connection
        /// </summary>
        /// Common Constructor
        public Common()
        {
            _objConnectionHandler = new ConnectionHandler();
            _objSqlConnection = _objConnectionHandler.CreateConnection();
        }


        /// <summary>
        /// Faizan Syed -
        /// ExecuteProcedure
        /// </summary>
        /// <param name="objCustomCommandModel"></param>
        /// <returns>CustomResponseModel</returns>
        /// Common/ExecuteProcedure
        public CustomResponseModel<T> ExecuteProcedure<T>(CustomCommandModel objCustomCommandModel)
        {
            CustomResponseModel<T> objCustomResponseModel = new CustomResponseModel<T>();
            try
            {
                _objSqlCommand = new SqlCommand
                {
                    Connection = _objSqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = objCustomCommandModel.ProcedureName
                };



                if (objCustomCommandModel.ParamArray != null)
                    _objSqlCommand.Parameters.AddRange(objCustomCommandModel.ParamArray);


                if (objCustomCommandModel.Type == ProcedureType.Get)
                {
                    SqlDataAdapter objDataAdapter = new SqlDataAdapter(_objSqlCommand);
                    DataTable dtResult = new DataTable();
                    objDataAdapter.Fill(dtResult);
                    objCustomResponseModel.ResultDataTable = ConvertDataTableToList<T>(dtResult);
                }
                else
                {
                    objCustomResponseModel.Status = _objSqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _objSqlCommand.Dispose();
                _objSqlConnection.Dispose();
                _objConnectionHandler.CloseConnection();
            }
            return objCustomResponseModel;
        }




        public static List<T> ConvertDataTableToList<T>(DataTable dataTable)
        {
            List<T> list = new List<T>();
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                T obj = Activator.CreateInstance<T>();
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    string fieldName = dataTable.Columns[j].ColumnName.ToString();
                    var prop = props.FirstOrDefault(x => x.Name.ToLower() == fieldName.ToLower());
                    if (prop != null && dataTable.Rows[i][j] != DBNull.Value)
                    {
                        prop.SetValue(obj, Convert.ChangeType(dataTable.Rows[i][j], prop.PropertyType));
                    }
                }
                list.Add(obj);
            }
            return list;
        }

    }

}
