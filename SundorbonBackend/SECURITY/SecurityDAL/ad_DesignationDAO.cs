using DbExecutor;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityDAL
{
    public class ad_DesignationDAO //: IDisposible
    {
        private static volatile ad_DesignationDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public ad_DesignationDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public static ad_DesignationDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new ad_DesignationDAO();
                    }

                return instance;
            }
        }

        public static ad_DesignationDAO GetInstance()
        {
            if (instance == null) instance = new ad_DesignationDAO();
            return instance;
        }

        public List<ad_Designation> GetAll()
        {
            try
            {
                var ad_DesignationLst = new List<ad_Designation>();

                ad_DesignationLst = dbExecutor.FetchData<ad_Designation>(CommandType.StoredProcedure, "ad_Designation_GetAll");
                return ad_DesignationLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_Section> GetAllSection()
        {
            try
            {
                var ad_SectionList = new List<ad_Section>();

                ad_SectionList = dbExecutor.FetchData<ad_Section>(CommandType.StoredProcedure, "ad_Section_GetAll");
                return ad_SectionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        



        public List<ad_Designation> GetByDepartmentId(int DepartmentId)
        {
            try
            {
                var ad_DesignationLst = new List<ad_Designation>();
                var colparameters = new Parameters[1]
                {
                    new Parameters("@DepartmentId", DepartmentId, DbType.Int32, ParameterDirection.Input)
                };
                ad_DesignationLst = dbExecutor.FetchData<ad_Designation>(CommandType.StoredProcedure,
                    "ad_Designation_GetByDepartmentId", colparameters);
                return ad_DesignationLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_Designation> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                var ad_DesignationLst = new List<ad_Designation>();
                var colparameters = new Parameters[2]
                {
                    new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
                    new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input)
                };
                ad_DesignationLst = dbExecutor.FetchData<ad_Designation>(CommandType.StoredProcedure,
                    "ad_Designation_GetDynamic", colparameters);
                return ad_DesignationLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_Designation> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
            string sortOrder, ref int rows)
        {
            try
            {
                var ad_DesignationLst = new List<ad_Designation>();
                var colparameters = new Parameters[5]
                {
                    new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
                    new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
                    new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input)
                };
                ad_DesignationLst = dbExecutor.FetchDataRef<ad_Designation>(CommandType.StoredProcedure,
                    "ad_Designation_GetPaged", colparameters, ref rows);
                return ad_DesignationLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_Grade> GradeGetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
          string sortOrder, ref int rows)
        {
            try
            {
                var ad_GradeList = new List<ad_Grade>();
                var colparameters = new Parameters[5]
                {
                    new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
                    new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
                    new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input)
                };
                ad_GradeList = dbExecutor.FetchDataRef<ad_Grade>(CommandType.StoredProcedure,
                    "ad_Grade_GetPaged", colparameters, ref rows);
                return ad_GradeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_Section> SectionGetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
        string sortOrder, ref int rows)
        {
            try
            {
                var ad_SectionList = new List<ad_Section>();
                var colparameters = new Parameters[5]
                {
                    new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
                    new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
                    new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input)
                };
                ad_SectionList = dbExecutor.FetchDataRef<ad_Section>(CommandType.StoredProcedure,
                    "ad_Section_GetPaged", colparameters, ref rows);
                return ad_SectionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int Add(ad_Designation ad_Designation)
        {
            var ret = 0;
            try
            {
                var colparameters = new Parameters[7]
                {
                    new Parameters("@DepartmentId", ad_Designation.DepartmentId, DbType.Int32,
                        ParameterDirection.Input),
                    new Parameters("@DesignationName", ad_Designation.DesignationName, DbType.String,
                        ParameterDirection.Input),
                    new Parameters("@ContactNo", ad_Designation.ContactNo, DbType.String, ParameterDirection.Input),
                    new Parameters("@SerialNo", ad_Designation.SerialNo, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@IsActive", ad_Designation.IsActive, DbType.Boolean, ParameterDirection.Input),
                    new Parameters("@CreatorId", ad_Designation.CreatorId, DbType.Int32, ParameterDirection.Input),
                    //new Parameters("@CreateDate", ad_Designation.CreateDate, DbType.DateTime, ParameterDirection.Input),
                 
                    new Parameters("@UpdatorId", ad_Designation.UpdatorId, DbType.Int32, ParameterDirection.Input)
                };
                dbExecutor.ManageTransaction(TransactionType.Open);
                ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_Designation_Create",
                    colparameters, true);
                dbExecutor.ManageTransaction(TransactionType.Commit);
            }
            catch (DBConcurrencyException except)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw except;
            }
            catch (Exception ex)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw ex;
            }

            return ret;
        }



        public int GradeSave(ad_Grade ad_Grade)
        {
            var ret = 0;
            try
            {
                var colparameters = new Parameters[5]
                {
                    new Parameters("@Id", ad_Grade.Id, DbType.Int32,
                        ParameterDirection.Input),
                    new Parameters("@Grade", ad_Grade.Grade, DbType.String,
                        ParameterDirection.Input),
                    new Parameters("@IsActive", ad_Grade.IsActive, DbType.Boolean, ParameterDirection.Input),
                    new Parameters("@CreatorId", ad_Grade.CreatorId, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@UpdatorId", ad_Grade.@UpdatorId, DbType.Int32, ParameterDirection.Input),

                };
                dbExecutor.ManageTransaction(TransactionType.Open);
                ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_Grade_Post",
                    colparameters, true);
                dbExecutor.ManageTransaction(TransactionType.Commit);
            }
            catch (DBConcurrencyException except)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw except;
            }
            catch (Exception ex)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw ex;
            }

            return ret;
        }


        public int SaveSection(ad_Section _ad_Section)
        {
            var ret = 0;
            try
            {
                var colparameters = new Parameters[6]
                {
                    new Parameters("@Id", _ad_Section.@Id, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@SectionName", _ad_Section.SectionName, DbType.String, ParameterDirection.Input),
                    new Parameters("@DepartmentId", _ad_Section.DepartmentId, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@IsActive", _ad_Section.IsActive, DbType.Boolean, ParameterDirection.Input),
                    new Parameters("@CreatorId", _ad_Section.CreatorId, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@UpdatorId", _ad_Section.UpdatorId, DbType.Int32, ParameterDirection.Input),

                };
                dbExecutor.ManageTransaction(TransactionType.Open);
                ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_Section_Post",
                    colparameters, true);
                dbExecutor.ManageTransaction(TransactionType.Commit);
            }
            catch (DBConcurrencyException except)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw except;
            }
            catch (Exception ex)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw ex;
            }

            return ret;
        }


        public int Update(ad_Designation ad_Designation)
        {
            var ret = 0;
            try
            {
                var colparameters = new Parameters[7]
                {
                    new Parameters("@DesignationId", ad_Designation.DesignationId, DbType.Int32,
                        ParameterDirection.Input),
                    new Parameters("@DepartmentId", ad_Designation.DepartmentId, DbType.Int32,
                        ParameterDirection.Input),
                    new Parameters("@DesignationName", ad_Designation.DesignationName, DbType.String,
                        ParameterDirection.Input),
                    new Parameters("@ContactNo", ad_Designation.ContactNo, DbType.String, ParameterDirection.Input),
                    new Parameters("@SerialNo", ad_Designation.SerialNo, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@IsActive", ad_Designation.IsActive, DbType.Boolean, ParameterDirection.Input),
                    new Parameters("@UpdatorId", ad_Designation.UpdatorId, DbType.Int32, ParameterDirection.Input),
                
                };
                ret = dbExecutor.ExecuteNonQuery(CommandType.StoredProcedure, "ad_Designation_Update", colparameters,
                    true);
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(int designationId)
        {
            try
            {
                var ret = 0;
                var colparameters = new Parameters[1]
                {
                    new Parameters("@DesignationId", designationId, DbType.Int32, ParameterDirection.Input)
                };
                ret = dbExecutor.ExecuteNonQuery(CommandType.StoredProcedure, "ad_Designation_DeleteById",
                    colparameters, true);
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
