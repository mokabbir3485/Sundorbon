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
    public class ws_IssueItemDAO
    {
		private static volatile ws_IssueItemDAO instance;
		private static readonly object lockObj = new object();
		public static ws_IssueItemDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_IssueItemDAO();
			}
			return instance;
		}
		public static ws_IssueItemDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_IssueItemDAO();
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

		public ws_IssueItemDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}
		public List<ws_IssueItem> GetAll()
		{
			try
			{
				List<ws_IssueItem> ws_JobDetailsLst = new List<ws_IssueItem>();
				//Parameters[] colparameters = new Parameters[1]{
				//new Parameters("@Number", Number, DbType.String, ParameterDirection.Input)
				//};
				ws_JobDetailsLst = dbExecutor.FetchData<ws_IssueItem>(CommandType.StoredProcedure, "Get_ws_Issueitem_Number");
				return ws_JobDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
