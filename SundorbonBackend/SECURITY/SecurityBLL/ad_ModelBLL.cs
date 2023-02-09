using SecurityEntity;
using Sundorbon.Backend.SECURITY.SecurityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class ad_ModelBLL //: IDisposible
    {
            public ad_ModelBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_ModelDAO = new ad_ModelDAO();
            }

        public ad_ModelDAO _ad_ModelDAO { get; set; }

        public int Add(ad_Model _ad_Model)
        {
            try
            {
                return _ad_ModelDAO.Add(_ad_Model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_Model> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _ad_ModelDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_Model> GetAll()
        {
            try
            {
                return _ad_ModelDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_Model> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_ModelDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
