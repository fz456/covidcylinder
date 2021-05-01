using HelpCylinder.BusinessEntities;
using HelpCylinder.BusinessLogic.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HelpRequests.BusinessLogic.BusinessLogic
{
    public class RequestsBAL
    {
        Common _objCommon;

        #region GetRequestsById

        /// <summary>
        /// Faizan Syed -
        /// return requests object
        /// </summary>
        /// <param name="objRequests"></param>
        /// <returns>Requests</returns>
        /// RequestsDAL/GetRequestsById
        public Request GetRequestsById(Request objRequests)
        {
            _objCommon = new Common();
            Request requests = new Request();
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel()
                {
                    ProcedureName = "[dbo].[usp_GetRequestsById]",
                    ParamArray = new SqlParameter[] { new SqlParameter("@RequestId", objRequests.RequestId) },
                    Type = ProcedureType.Get
                };
                CustomResponseModel<Request> objCustomResponseModel;
                objCustomResponseModel = _objCommon.ExecuteProcedure<Request>(objCustomCommandModel);
                requests = objCustomResponseModel.ResultDataTable.FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return requests;
        }
        #endregion

        #region SelectQuery

        /// <summary>
        /// Faizan Syed -
        /// return requests list
        /// </summary>
        /// <returns> IList<Requests> </returns>
        /// RequestsDAL/GetRequestsList
        public IList<Request> GetRequestsList()
        {
            _objCommon = new Common();
            List<Request> lstRequests = new List<Request>();
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel()
                {
                    ProcedureName = "[dbo].[usp_GetGetRequestsList]",
                    Type = ProcedureType.Get
                };
                CustomResponseModel<Request> objCustomResponseModel;
                objCustomResponseModel = _objCommon.ExecuteProcedure<Request>(objCustomCommandModel);
                lstRequests = objCustomResponseModel.ResultDataTable;
            }
            catch (Exception ex)
            {

            }
            return lstRequests;
        }
        #endregion

        #region InsertRequests

        /// <summary>
        ///  - Faizan Syed -
        /// add requests
        /// </summary>
        /// <param name="objRequests"></param>
        /// <returns> CustomResponseModel </returns>
        /// RequestsDAL/InsertRequests
        /// 
        public CustomResponseModel<Request> InsertRequest(Request objRequests)
        {
            _objCommon = new Common();
            CustomResponseModel<Request> objCustomResponseModel = null;
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel
                {
                    ProcedureName = "[dbo].[usp_InsertRequest]",
                    ParamArray = new SqlParameter[]
                    {
                        new SqlParameter("@PatientName",objRequests.PatientName),
                        new SqlParameter("@PatientMobileNo",objRequests.PatientMobileNo)
                    },
                    Type = ProcedureType.Post
                };
                objCustomResponseModel = _objCommon.ExecuteProcedure<Request>(objCustomCommandModel);
            }
            catch (Exception ex)
            {

            }
            return objCustomResponseModel;
        }
        #endregion

        #region UpdateRequests

        /// <summary>
        ///  - Faizan Syed -
        /// update requests
        /// </summary>
        /// <param name="objRequests"></param>
        /// <returns> CustomResponseModel </returns>
        /// RequestsDAL/UpdateRequests
        ///
        public CustomResponseModel<Request> UpdateRequest(Request objRequests)
        {
            _objCommon = new Common();
            CustomResponseModel<Request> objCustomResponseModel = null;
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel
                {
                    ProcedureName = "[dbo].[usp_UpdateRequest]",
                    ParamArray = new SqlParameter[]
                    {
                        new SqlParameter( "@RequestId", objRequests.RequestId),
                        new SqlParameter("@PatientName",objRequests.PatientName),
                        new SqlParameter("@PatientMobileNo",objRequests.PatientMobileNo)
                    },
                    Type = ProcedureType.Post
                };
                objCustomResponseModel = _objCommon.ExecuteProcedure<Request>(objCustomCommandModel);
            }
            catch (Exception ex)
            {

            }
            return objCustomResponseModel;
        }
        #endregion

        #region DeleteRequests

        /// <summary>
        ///  - Faizan Syed -
        /// delete requests
        /// </summary>
        /// <param name="objRequests"></param>
        /// <returns> CustomResponseModel </returns>
        /// RequestsDAL/DeleteRequests
        public CustomResponseModel<Request> DeleteRequest(Request objRequests)
        {
            _objCommon = new Common();
            CustomResponseModel<Request> objCustomResponseModel = null;
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel
                {
                    ProcedureName = "[dbo].[usp_DeleteRequest]",
                    ParamArray = new SqlParameter[]
                  {
                        new SqlParameter( "@RequestId", objRequests.RequestId),
                  },
                    Type = ProcedureType.Post
                };
                objCustomResponseModel = _objCommon.ExecuteProcedure<Request>(objCustomCommandModel);
            }
            catch (Exception ex)
            {

            }
            return objCustomResponseModel;
        }
        #endregion
    }
}
