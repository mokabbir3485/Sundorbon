using SecurityEntity;
using Sundorbon.Backend.SECURITY.SecurityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using SecurityDAL;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class ad_EmployeeBLL //: IDisposible
    {
            public ad_EmployeeBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
              _ad_EmployeeDAO = new ad_EmployeeDAO();
            }

        public ad_EmployeeDAO _ad_EmployeeDAO { get; set; }

        public int Add(ad_Employee _ad_Employee)
        {
            try
            {
                return _ad_EmployeeDAO.Add(_ad_Employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_Employee> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _ad_EmployeeDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_Employee> GetAll()
        {
            try
            {
                return _ad_EmployeeDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_Employee> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_EmployeeDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
