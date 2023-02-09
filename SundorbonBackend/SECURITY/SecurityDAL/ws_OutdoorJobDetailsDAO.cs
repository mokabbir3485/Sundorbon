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
    public class ws_OutdoorJobDetailsDAO
    {
        private static volatile ws_OutdoorJobDetailsDAO instance;
        private static readonly object lockObj = new object();
        public static ws_OutdoorJobDetailsDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new ws_OutdoorJobDetailsDAO();
            }
            return instance;
        }
        public static ws_OutdoorJobDetailsDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new ws_OutdoorJobDetailsDAO();
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

        public ws_OutdoorJobDetailsDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public List<wsOutDoorJobDetails> GetAll()
        {
            try
            {
                List<wsOutDoorJobDetails> ws_OutdoorJobDetailsLst = new List<wsOutDoorJobDetails>();

                ws_OutdoorJobDetailsLst = dbExecutor.FetchData<wsOutDoorJobDetails>(CommandType.StoredProcedure, "ws_OutdoorJobDetails_GetAll");
                return ws_OutdoorJobDetailsLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<wsOutDoorJobDetails> GetAllByJobNumber(string Number)
        {
            try
            {
                List<wsOutDoorJobDetails> ws_OutdoorJobDetailsLst = new List<wsOutDoorJobDetails>();
                Parameters[] colparameters = new Parameters[1]{
                    new Parameters("@Number", Number, DbType.String, ParameterDirection.Input)
                };
                ws_OutdoorJobDetailsLst = dbExecutor.FetchData<wsOutDoorJobDetails>(CommandType.StoredProcedure, "ws_OutdoorJobDetails_GetAll_By_JobNumber", colparameters);
                return ws_OutdoorJobDetailsLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //      public List<ws_OutdoorJobDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
        //{
        //	try
        //	{
        //		List<ws_OutdoorJobDetails> ws_OutdoorJobDetailsLst = new List<ws_OutdoorJobDetails>();
        //		Parameters[] colparameters = new Parameters[5]{
        //		new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
        //		new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
        //		new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
        //		new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
        //		new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
        //		};
        //		ws_OutdoorJobDetailsLst = dbExecutor.FetchDataRef<ws_OutdoorJobDetails>(CommandType.StoredProcedure, "ws_OutdoorJobDetails_GetPaged", colparameters, ref rows);
        //		return ws_OutdoorJobDetailsLst;
        //	}
        //	catch (Exception ex)
        //	{
        //		throw ex;
        //	}
        //}

        public string Post(wsOutDoorJobDetails _ws_OutdoorJobDetails, string transactionType)
        {
            string ret = string.Empty;
            try
            {
                Parameters[] colparameters = new Parameters[5]{

                new Parameters("@Id", _ws_OutdoorJobDetails.Id, DbType.Int32, ParameterDirection.Input),
                new Parameters("@OJobNumber", _ws_OutdoorJobDetails.OJobNumber, DbType.String, ParameterDirection.Input),
                new Parameters("@OWorkDetails", _ws_OutdoorJobDetails.OutdoorWorkDetails, DbType.String, ParameterDirection.Input),
                new Parameters("@IsVoid", _ws_OutdoorJobDetails.IsVoid, DbType.Int32, ParameterDirection.Input),
                new Parameters("@TransactiontionType", transactionType, DbType.String, ParameterDirection.Input),

                };

                dbExecutor.ManageTransaction(TransactionType.Open);
                ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "ws_OutdoorJobDetails_Post", colparameters, true);
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
