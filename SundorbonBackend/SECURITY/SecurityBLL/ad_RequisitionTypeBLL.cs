using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtrialDAL;
using XtrialEntity;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_RequisitionTypeBLL
    {
        public ad_RequisitionTypeBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_RequistionTypeDAO = new ad_RequistionTypeDAO();
        }

        public ad_RequistionTypeDAO _ad_RequistionTypeDAO { get; set; }

        public int Add(ad_RequistionType _ad_RequistionType)
        {
            try
            {
                return _ad_RequistionTypeDAO.Post(_ad_RequistionType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_RequistionType> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _ad_RequistionTypeDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_RequistionType> GetAll()
        {
            try
            {
                return _ad_RequistionTypeDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //public List<ad_RequistionType> GetAll()
        //{
        //    try
        //    {
        //        return _ad_RequistionTypeDAO.GetAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<ad_RequistionType> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_RequistionTypeDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
