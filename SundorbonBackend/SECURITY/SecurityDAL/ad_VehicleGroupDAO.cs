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
    public class ad_VehicleGroupDAO
    {
        private static volatile ad_VehicleGroupDAO instance;
        private static readonly object lockObj = new object();
        public static ad_VehicleGroupDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new ad_VehicleGroupDAO();
            }
            return instance;
        }
        public static ad_VehicleGroupDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new ad_VehicleGroupDAO();
                        }
                    }
                }
                return instance;
            }
        }

        public void Dispose()
        {
            ((IDisposable)GetInstanceThreadSafe).Dispose();
        }

        DBExecutor dbExecutor;

        public ad_VehicleGroupDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }
        public List<ad_VehicleGroup> GetAll()
        {
            try
            {
                var ad_ModelList = new List<ad_VehicleGroup>();
                ad_ModelList =
                    dbExecutor.FetchData<ad_VehicleGroup>(CommandType.StoredProcedure, "ad_VehicleGroup_GetAll_Active");
                return ad_ModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_VehicleGroup> Get(Int32? id = null)
        {
            try
            {
                List<ad_VehicleGroup> ad_VehicleGroupLst = new List<ad_VehicleGroup>();
                Parameters[] colparameters = new Parameters[1]{
                new Parameters("@Id", id, DbType.Int32, ParameterDirection.Input)
                };
                ad_VehicleGroupLst = dbExecutor.FetchData<ad_VehicleGroup>(CommandType.StoredProcedure, "ad_VehicleGroup_Get", colparameters);
                return ad_VehicleGroupLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_VehicleGroup> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                List<ad_VehicleGroup> ad_VehicleGroupLst = new List<ad_VehicleGroup>();
                Parameters[] colparameters = new Parameters[2]{
                new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
                new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input),
                };
                ad_VehicleGroupLst = dbExecutor.FetchData<ad_VehicleGroup>(CommandType.StoredProcedure, "ad_VehicleGroup_GetDynamic", colparameters);
                return ad_VehicleGroupLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_VehicleGroup> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
        {
            try
            {
                List<ad_VehicleGroup> ad_VehicleGroupLst = new List<ad_VehicleGroup>();
                Parameters[] colparameters = new Parameters[5]{
                new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
                new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
                new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
                new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
                new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
                };
                ad_VehicleGroupLst = dbExecutor.FetchDataRef<ad_VehicleGroup>(CommandType.StoredProcedure, "ad_VehicleGroup_GetPaged", colparameters, ref rows);
                return ad_VehicleGroupLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add(ad_VehicleGroup _ad_VehicleGroup)
        {
            int ret = 0;
            try
            {
                Parameters[] colparameters = new Parameters[5]{
                new Parameters("@Id", _ad_VehicleGroup.Id, DbType.Int32, ParameterDirection.Input),
                new Parameters("@GroupName", _ad_VehicleGroup.GroupName, DbType.String, ParameterDirection.Input),
                new Parameters("@IsActive", _ad_VehicleGroup.IsActive, DbType.Boolean, ParameterDirection.Input),
                new Parameters("@CreatorId", _ad_VehicleGroup.CreatorId, DbType.Int32, ParameterDirection.Input),
                new Parameters("@UpdatorId", _ad_VehicleGroup.UpdatorId, DbType.Int32, ParameterDirection.Input)
                };
                dbExecutor.ManageTransaction(TransactionType.Open);
                ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_VehicleGroup_Post", colparameters, true);
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

    }
}
