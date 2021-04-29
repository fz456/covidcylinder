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
        ///  - Faizan Syed -
        /// return requests object
        /// </summary>
        /// <param name="objRequests"></param>
        /// <returns>Requests</returns>
        /// RequestsDAL/GetRequestsById
        public Requests GetRequestsById(Requests objRequests)
        {
            _objCommon = new Common();
            Requests requests = new Requests();
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel()
                {
                    ProcedureName = "",
                    ParamArray = new SqlParameter[] { new SqlParameter("@Rid", objRequests.Rid) },
                    Type = ProcedureType.Get
                };
                CustomResponseModel<Requests> objCustomResponseModel;
                objCustomResponseModel = _objCommon.ExecuteProcedure<Requests>(objCustomCommandModel);
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
        ///  - Faizan Syed -
        /// return requests list
        /// </summary>
        /// <returns> IList<Requests> </returns>
        /// RequestsDAL/GetRequestsList
        public IList<Requests> GetRequestsList()
        {
            _objCommon = new Common();
            List<Requests> lstRequests = new List<Requests>();
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel()
                {
                    ProcedureName = "",
                    Type = ProcedureType.Get
                };
                CustomResponseModel<Requests> objCustomResponseModel;
                objCustomResponseModel = _objCommon.ExecuteProcedure<Requests>(objCustomCommandModel);
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
        public CustomResponseModel<Requests> InsertRequests(Requests objRequests)
        {
            _objCommon = new Common();
            CustomResponseModel<Requests> objCustomResponseModel = null;
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel
                {
                    ProcedureName = "",
                    ParamArray = new SqlParameter[]
                    {
                        new SqlParameter("@PatientName",objRequests.PatientName),
                        new SqlParameter("@PatientMobileNo",objRequests.PatientMobileNo)
                    },
                    Type = ProcedureType.Post
                };
                objCustomResponseModel = _objCommon.ExecuteProcedure<Requests>(objCustomCommandModel);
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
        public CustomResponseModel<Requests> UpdateRequests(Requests objRequests)
        {
            _objCommon = new Common();
            CustomResponseModel<Requests> objCustomResponseModel = null;
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel
                {
                    ProcedureName = "",
                    ParamArray = new SqlParameter[]
                    {
                        new SqlParameter( "@Rid", objRequests.Rid),
                        new SqlParameter("@PatientName",objRequests.PatientName),
                        new SqlParameter("@PatientMobileNo",objRequests.PatientMobileNo)
                    },
                    Type = ProcedureType.Post
                };
                objCustomResponseModel = _objCommon.ExecuteProcedure<Requests>(objCustomCommandModel);
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
        public CustomResponseModel<Requests> DeleteRequests(Requests objRequests)
        {
            _objCommon = new Common();
            CustomResponseModel<Requests> objCustomResponseModel = null;
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel
                {
                    ProcedureName = "",
                    ParamArray = new SqlParameter[]
                  {
                        new SqlParameter( "@Rid", objRequests.Rid),
                  },
                    Type = ProcedureType.Post
                };
                objCustomResponseModel = _objCommon.ExecuteProcedure<Requests>(objCustomCommandModel);
            }
            catch (Exception ex)
            {

            }
            return objCustomResponseModel;
        }
        #endregion
    }
}
