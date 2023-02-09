using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_DepartmentBLL
    {
        public ad_DepartmentBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_DepartmentDAO = new ad_DepartmentDAO();
        }
        public List<ad_Depertment> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_DepartmentDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ad_DepartmentDAO _ad_DepartmentDAO { get; set; }
        public List<ad_Depertment> GetAll()
        {
            try
            {
                return _ad_DepartmentDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add(ad_Depertment _ad_Depertment)
        {
            try
            {
                return _ad_DepartmentDAO.Add(_ad_Depertment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
