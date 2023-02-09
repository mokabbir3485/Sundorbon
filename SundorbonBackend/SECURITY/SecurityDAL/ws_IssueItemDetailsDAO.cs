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
    public class ws_IssueItemDetailsDAO
    {
		private static volatile ws_IssueItemDetailsDAO instance;
		private static readonly object lockObj = new object();
		public static ws_IssueItemDetailsDAO GetInstance()
		{
			if (instance == null)
			{
				instance = new ws_IssueItemDetailsDAO();
			}
			return instance;
		}
		public static ws_IssueItemDetailsDAO GetInstanceThreadSafe
		{
			get
			{
				if (instance == null)
				{
					lock (lockObj)
					{
						if (instance == null)
						{
							instance = new ws_IssueItemDetailsDAO();
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

		public ws_IssueItemDetailsDAO()
		{
			//dbExecutor = DBExecutor.GetInstanceThreadSafe;
			dbExecutor = new DBExecutor();
		}
		public List<ws_IssueItemDetails> GetAll(string Number)
		{
			try
			{
				List<ws_IssueItemDetails> ws_JobDetailsLst = new List<ws_IssueItemDetails>();
                Parameters[] colparameters = new Parameters[1]{
                new Parameters("@Number", Number, DbType.String, ParameterDirection.Input)
                };
                ws_JobDetailsLst = dbExecutor.FetchData<ws_IssueItemDetails>(CommandType.StoredProcedure, "Get_ws_IssueitemDetail_Number", colparameters);
				return ws_JobDetailsLst;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
