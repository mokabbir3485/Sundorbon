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
    public class inv_StoreIssueDetailsDAO
    {
		private static volatile inv_StoreIssueDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static inv_StoreIssueDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new inv_StoreIssueDetailsDAO();
			}
			return instance;
		}
		public static inv_StoreIssueDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new inv_StoreIssueDetailsDAO();
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

		public inv_StoreIssueDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}

		public List<inv_StoreIssueDetails> GetByStoreIssueNumber(string Number)
		{
			try
			{
				List<inv_StoreIssueDetails> inv_StoreIssueDetailsLst = new List<inv_StoreIssueDetails>();
				Parameters[] colparameters = new Parameters[1]{
				new Parameters("@IssueNo", Number, DbType.String, ParameterDirection.Input)
				};
				inv_StoreIssueDetailsLst = dbExecutor.FetchData<inv_StoreIssueDetails>(CommandType.StoredProcedure, "ws_Get_StoareIssue_Details", colparameters);
				return inv_StoreIssueDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
