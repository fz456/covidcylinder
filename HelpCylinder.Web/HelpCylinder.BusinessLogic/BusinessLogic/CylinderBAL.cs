using HelpCylinder.BusinessEntities;
using HelpCylinder.BusinessLogic.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HelpCylinder.BusinessLogic.BusinessLogic
{
    public class CylinderBAL
    {
        Common _objCommon;

        #region GetCylinderById

        /// <summary>
        ///  - Faizan Syed -
        /// return cylinder object
        /// </summary>
        /// <param name="objCylinder"></param>
        /// <returns>Cylinder</returns>
        /// CylinderDAL/GetCylinderById
        public Cylinder GetCylinderById(Cylinder objCylinder)
        {
            _objCommon = new Common();
            Cylinder cylinder = new Cylinder();
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel()
                {
                    ProcedureName = "[dbo].[usp_GetCylinderById]",
                    ParamArray = new SqlParameter[] { new SqlParameter("@cylinderId", objCylinder.CylinderId) },
                    Type = ProcedureType.Get
                };
                CustomResponseModel<Cylinder> objCustomResponseModel;
                objCustomResponseModel = _objCommon.ExecuteProcedure<Cylinder>(objCustomCommandModel);
                cylinder = objCustomResponseModel.ResultDataTable.FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return cylinder;
        }
        #endregion

        #region SelectQuery

        /// <summary>
        ///  - Faizan Syed -
        /// return cylinder list
        /// </summary>
        /// <returns> IList<Cylinder> </returns>
        /// CylinderDAL/GetCylinderList
        public IList<Cylinder> GetAvailableCylinderList(long UserIntId)
        {
            _objCommon = new Common();
            List<Cylinder> lstCylinder = new List<Cylinder>();
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel()
                {
                    ProcedureName = "[dbo].[usp_GetAvailableCylinderList]",
                    ParamArray = new SqlParameter[]
                    {
                        new SqlParameter("@UserIntId",UserIntId)
                    },
                    Type = ProcedureType.Get
                };
                CustomResponseModel<Cylinder> objCustomResponseModel;
                objCustomResponseModel = _objCommon.ExecuteProcedure<Cylinder>(objCustomCommandModel);
                lstCylinder = objCustomResponseModel.ResultDataTable;
            }
            catch (Exception ex)
            {

            }
            return lstCylinder;
        }
        #endregion

        #region InsertCylinder

        /// <summary>
        ///  - Faizan Syed -
        /// add cylinder
        /// </summary>
        /// <param name="objCylinder"></param>
        /// <returns> CustomResponseModel </returns>
        /// CylinderDAL/InsertCylinder
        /// 
        public CustomResponseModel<Cylinder> InsertCylinder(Cylinder objCylinder)
        {
            _objCommon = new Common();
            CustomResponseModel<Cylinder> objCustomResponseModel = null;
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel
                {
                    ProcedureName = "[dbo].[usp_InsertCylinder]",
                    ParamArray = new SqlParameter[]
                    {
                        new SqlParameter("@Code",objCylinder.Code),
                        new SqlParameter("@CylinderName",objCylinder.CylinderName),
                        new SqlParameter("@IsActive",objCylinder.IsActive),
                    },
                    Type = ProcedureType.Post
                };
                objCustomResponseModel = _objCommon.ExecuteProcedure<Cylinder>(objCustomCommandModel);
            }
            catch (Exception ex)
            {

            }
            return objCustomResponseModel;
        }
        #endregion

        #region UpdateCylinder

        /// <summary>
        ///  - Faizan Syed -
        /// update cylinder
        /// </summary>
        /// <param name="objCylinder"></param>
        /// <returns> CustomResponseModel </returns>
        /// CylinderDAL/UpdateCylinder
        ///
        public CustomResponseModel<Cylinder> UpdateCylinder(Cylinder objCylinder)
        {
            _objCommon = new Common();
            CustomResponseModel<Cylinder> objCustomResponseModel = null;
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel
                {
                    ProcedureName = "[dbo].[usp_UpdateCylinder]",
                    ParamArray = new SqlParameter[]
                    {
                        new SqlParameter("@CylinderId", objCylinder.CylinderId),
                        new SqlParameter("@Code" , objCylinder.Code),
                        new SqlParameter("@IsActive",objCylinder.IsActive),
                        new SqlParameter("@CylinderName",objCylinder.CylinderName)
                    },
                    Type = ProcedureType.Post
                };
                objCustomResponseModel = _objCommon.ExecuteProcedure<Cylinder>(objCustomCommandModel);
            }
            catch (Exception ex)
            {

            }
            return objCustomResponseModel;
        }
        #endregion

        #region DeleteCylinder

        /// <summary>
        ///  - Faizan Syed -
        /// delete cylinder
        /// </summary>
        /// <param name="objCylinder"></param>
        /// <returns> CustomResponseModel </returns>
        /// CylinderDAL/DeleteCylinder
        public CustomResponseModel<Cylinder> DeleteCylinder(Cylinder objCylinder)
        {
            _objCommon = new Common();
            CustomResponseModel<Cylinder> objCustomResponseModel = null;
            try
            {
                CustomCommandModel objCustomCommandModel = new CustomCommandModel
                {
                    ProcedureName = "[dbo].[usp_DeleteCylinder]",
                    ParamArray = new SqlParameter[]
                  {
                        new SqlParameter( "@CylinderId", objCylinder.CylinderId)
                  },
                    Type = ProcedureType.Post
                };
                objCustomResponseModel = _objCommon.ExecuteProcedure<Cylinder>(objCustomCommandModel);
            }
            catch (Exception ex)
            {

            }
            return objCustomResponseModel;
        }
        #endregion
    }
}
