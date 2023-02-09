using SecurityEntity;
using Sundorbon.Backend.SECURITY.SecurityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sundorbon.Backend.SECURITY.SecurityEntity;
namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class ad_VATBLL //: IDisposible
        {
            public ad_VATBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_VATDAO = new ad_VATDAO();
            }

        public ad_VATDAO _ad_VATDAO { get; set; }

        public int Add(ad_VAT _ad_VAT)
        {
            try
            {
                return _ad_VATDAO.Post(_ad_VAT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_VAT> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _ad_VATDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_VAT> GetAll()
        {
            try
            {
                return _ad_VATDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_VAT> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_VATDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
