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
    public class ws_OutdoorJobItemDetailsDAO
    {
		private static volatile ws_OutdoorJobItemDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static ws_OutdoorJobItemDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_OutdoorJobItemDetailsDAO();
			}
			return instance;
		}
		public static ws_OutdoorJobItemDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_OutdoorJobItemDetailsDAO();
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

		public ws_OutdoorJobItemDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<ws_OutdoorJobItemDetails> GetByJobNumber(string Number)
		{
			try
			{
				List<ws_OutdoorJobItemDetails> ws_OutdoorJobItemDetailsLst = new List<ws_OutdoorJobItemDetails>();
				Parameters[] colparameters = new Parameters[1]{
					new Parameters("@Number", Number, DbType.String, ParameterDirection.Input)
				};
				ws_OutdoorJobItemDetailsLst = dbExecutor.FetchData<ws_OutdoorJobItemDetails>(CommandType.StoredProcedure, "ws_OutdoorJobItemDetails_GetAll_By_OJobNumber", colparameters);
				return ws_OutdoorJobItemDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//public List<ws_OutdoorJobItemDetails> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn, string sortOrder, ref int rows)
		//{
		//	try
		//	{
		//		List<ws_OutdoorJobItemDetails> ws_OutdoorJobItemDetailsLst = new List<ws_OutdoorJobItemDetails>();
		//		Parameters[] colparameters = new Parameters[5]{
		//		new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
		//		new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
		//		new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
		//		new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
		//		new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input),
		//		};
		//		ws_OutdoorJobItemDetailsLst = dbExecutor.FetchDataRef<ws_OutdoorJobItemDetails>(CommandType.StoredProcedure, "ws_OutdoorJobItemDetails_GetPaged", colparameters, ref rows);
		//		return ws_OutdoorJobItemDetailsLst;
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//}

		public string Post(ws_OutdoorJobItemDetails _ws_OutdoorJobItemDetails, string transactionType)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[9]{

				new Parameters("@Id", _ws_OutdoorJobItemDetails.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@OJobNumber", _ws_OutdoorJobItemDetails.OJobNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@ItemId", _ws_OutdoorJobItemDetails.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ItemRequiredFromOutdoorQty	", _ws_OutdoorJobItemDetails.ItemRequiredFromOutdoorQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@OItemReusableQty", _ws_OutdoorJobItemDetails.OItemReusableQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@ItemDamagedQty", _ws_OutdoorJobItemDetails.ItemDamagedQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@IsVoid", _ws_OutdoorJobItemDetails.IsVoid, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@Remarks", _ws_OutdoorJobItemDetails.Remarks, DbType.String, ParameterDirection.Input),
				new Parameters("@TransactiontionType", transactionType, DbType.String, ParameterDirection.Input),

				};

				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "ws_OutdoorJobItemDetails_Post", colparameters, true);
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
