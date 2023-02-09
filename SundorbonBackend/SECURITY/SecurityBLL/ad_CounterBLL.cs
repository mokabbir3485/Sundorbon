using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_CounterBLL
    {
        public ad_CounterBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_CounterDAO = new ad_CounterDAO();
        }

        public ad_CounterDAO _ad_CounterDAO { get; set; }
        public List<ad_Counter> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_CounterDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add(ad_Counter _ad_Counter)
        {
            try
            {
                return _ad_CounterDAO.Add(_ad_Counter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_Counter> GetAll()
        {
            try
            {
                return _ad_CounterDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_Counter> GetAllNotUsedCounter(int DeptId)
        {
            try
            {
                return _ad_CounterDAO.GetAllNotUsedCounter(DeptId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ChangeUsedStatus(int id, bool status)
        {
            try
            {
                return _ad_CounterDAO.ChangeUsedStatus(id,status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
