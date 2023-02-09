using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtrialDAL;
using XtrialEntity;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_PurposeBLL
    {
        public ad_PurposeBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_PurposeDAO = new ad_PurposeDAO();
        }

        public ad_PurposeDAO _ad_PurposeDAO { get; set; }

        public int Add(ad_Purpose _ad_Purpose)
        {
            try
            {
                return _ad_PurposeDAO.Post(_ad_Purpose);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_Purpose> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _ad_PurposeDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<ad_Purpose> GetAll()
        //{
        //    try
        //    {
        //        return _ad_PurposeDAO.GetAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<ad_Purpose> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_PurposeDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
