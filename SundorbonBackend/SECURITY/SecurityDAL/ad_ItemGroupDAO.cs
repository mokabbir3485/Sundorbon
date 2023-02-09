using DbExecutor;
using SecurityEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sundorbon.Backend.SECURITY.SecurityEntity;
namespace Sundorbon.Backend.SECURITY.SecurityDAL
{
   public class ad_ItemGroupDAO
    {
        private static volatile ad_ItemGroupDAO instance;  //created static object of ad_ItemGroupDAO Class
        private static readonly object lockObj = new object(); //created static object of object Class

        private readonly DBExecutor dbExecutor; //created  object of DBExecutor Class

        public ad_ItemGroupDAO() // Constructor of ad_ItemGroupDAO  Class without parameter.
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();  //initialized dbExecutor object
        }

        public static ad_ItemGroupDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new ad_ItemGroupDAO();
                    }

                return instance;
            }
        }

        public static ad_ItemGroupDAO GetInstance()
        {
            if (instance == null) instance = new ad_ItemGroupDAO();
            return instance;
        }

        public int Add(ad_ItemGroup _ItemGroup)
        {
            var ret = 0;
            try
            {
                var colparameters = new Parameters[5]
                {
                     new Parameters("@Id", _ItemGroup.Id, DbType.Int32,
                        ParameterDirection.Input),
                    new Parameters("@GroupName", _ItemGroup.GroupName, DbType.String,
                        ParameterDirection.Input),
                    new Parameters("@IsActive", _ItemGroup.IsActive, DbType.Boolean, ParameterDirection.Input),
                    new Parameters("@CreatorId", _ItemGroup.CreatorId, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@UpdatorId", _ItemGroup.UpdatorId, DbType.Int32, ParameterDirection.Input),
                   
                };
                dbExecutor.ManageTransaction(TransactionType.Open);
                ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_ItemGroup_Post",
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
        public List<ad_ItemGroup> GetAll()
        {
            try
            {
                var ad_ItemGroupLst = new List<ad_ItemGroup>();
                ad_ItemGroupLst =
                    dbExecutor.FetchData<ad_ItemGroup>(CommandType.StoredProcedure, "ad_ItemGroup_GetAllActive");
                return ad_ItemGroupLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_ItemGroup> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                var ad_PaymentGroupLst = new List<ad_ItemGroup>();
                var colparameters = new Parameters[2]
                {
                    new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
                    new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input)
                };
                ad_PaymentGroupLst = dbExecutor.FetchData<ad_ItemGroup>(CommandType.StoredProcedure,
                    "ad_ItemGroup_GetDynamic", colparameters);
                return ad_PaymentGroupLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_ItemGroup> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
           string sortOrder, ref int rows)
        {
            try
            {
                var ad_BankLst = new List<ad_ItemGroup>();
                var colparameters = new Parameters[5]
                {
                    new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
                    new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
                    new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
                    new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input)
                };
                ad_BankLst = dbExecutor.FetchDataRef<ad_ItemGroup>(CommandType.StoredProcedure, "ad_ItemGroup_GetPaged",
                    colparameters, ref rows);
                return ad_BankLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
