using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HelpCylinder.BusinessLogic.DataAccess
{
    public class ConnectionHandler
    {
        string _connectionString;
        SqlConnection _objConnection;

        /// <summary>
        ///  Faizan Syed -
        /// Initialize _connectionString
        /// </summary>
        /// ConnectionHandler Constructor
        public ConnectionHandler()
        {
            _connectionString = "Data Source=13.235.146.133;Initial Catalog=FREECYLINDER;User=User_FC;password=Freecyl1@12";
        }

        /// <summary>
        ///  Faizan Syed -
        /// Create Databese Connection
        /// </summary>
        /// <returns>Connection object</returns>
        /// ConnectionHandler/CreateConnection
        public SqlConnection CreateConnection()
        {
            _objConnection = new SqlConnection(_connectionString);
            if (_objConnection.State != ConnectionState.Open)
            {
                _objConnection.Open();
            }
            return _objConnection;
        }

        /// <summary>
        ///  Faizan Syed -
        /// Close Databese Connection
        /// </summary>
        /// ConnectionHandler/CloseConnection
        public void CloseConnection()

        {
            if (_objConnection.State != ConnectionState.Closed)
                _objConnection.Close();
        }

    }
}
