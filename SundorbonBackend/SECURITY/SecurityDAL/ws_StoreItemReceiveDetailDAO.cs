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
    public class ws_StoreItemReceiveDetailDAO
    {
		private static volatile ws_StoreItemReceiveDetailDAO instance;
		private static readonly object lockObj = new object();
		public static ws_StoreItemReceiveDetailDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_StoreItemReceiveDetailDAO();
			}
			return instance;
		}
		public static ws_StoreItemReceiveDetailDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_StoreItemReceiveDetailDAO();
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

		public ws_StoreItemReceiveDetailDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}
		public string Post(ws_StoreItemReceiveDetails _ws_StoreItemReceiveDetail)
		{
			string ret = string.Empty;
			try
			{
				Parameters[] colparameters = new Parameters[10]{

				new Parameters("@Id", _ws_StoreItemReceiveDetail.Id, DbType.Int32, ParameterDirection.Input),
				new Parameters("@StoreReceiveNumber", _ws_StoreItemReceiveDetail.StoreReceiveNumber, DbType.String, ParameterDirection.Input),
				new Parameters("@StoreId", _ws_StoreItemReceiveDetail.StoreId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@RackId", _ws_StoreItemReceiveDetail.RackId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@ItemId", _ws_StoreItemReceiveDetail.ItemId, DbType.Int32, ParameterDirection.Input),
				new Parameters("@Remarks", _ws_StoreItemReceiveDetail.Remarks, DbType.String, ParameterDirection.Input),
				new Parameters("@ReceiveQty", _ws_StoreItemReceiveDetail.ReceiveQty, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@ReceivedPrice", _ws_StoreItemReceiveDetail.ReceivedPrice, DbType.Decimal, ParameterDirection.Input),
				new Parameters("@IsVoid", _ws_StoreItemReceiveDetail.IsVoid, DbType.Boolean, ParameterDirection.Input),
				new Parameters("@TransactiontionType", _ws_StoreItemReceiveDetail.TransactiontionType, DbType.String, ParameterDirection.Input),

				};

				dbExecutor.ManageTransaction(TransactionType.Open);
				ret = dbExecutor.ExecuteScalarString(true, CommandType.StoredProcedure, "ws_StoreItemReceiveDetails_Post", colparameters, true);
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
