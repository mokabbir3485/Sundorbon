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
      public class ad_ItemGroupBLL //: IDisposible
        {
            public ad_ItemGroupBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
              _ad_ItemGroupDAO = new ad_ItemGroupDAO();
            }

        public ad_ItemGroupDAO _ad_ItemGroupDAO { get; set; }

        public int Add(ad_ItemGroup _ad_ItemGroup)
        {
            try
            {
                return _ad_ItemGroupDAO.Add(_ad_ItemGroup);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_ItemGroup> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _ad_ItemGroupDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_ItemGroup> GetAll()
        {
            try
            {
                return _ad_ItemGroupDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_ItemGroup> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_ItemGroupDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
