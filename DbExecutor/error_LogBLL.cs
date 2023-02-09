using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DbExecutor
{
	public class error_LogBLL //: IDisposible
	{
		public error_LogDAO  error_LogDAO { get; set; }

		public error_LogBLL()
		{
			//error_LogDAO = error_Log.GetInstanceThreadSafe;
			error_LogDAO = new error_LogDAO();
		}

		public List<error_Log> GetAll()
		{
			try
			{
				return error_LogDAO.GetAll();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public int Add(error_Log _error_Log)
		{
			try
			{
				return error_LogDAO.Add(_error_Log);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Update(error_Log _error_Log)
		{
			try
			{
				return error_LogDAO.Update(_error_Log);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int Delete(Int64 errorId)
		{
			try
			{
				return error_LogDAO.Delete(errorId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
