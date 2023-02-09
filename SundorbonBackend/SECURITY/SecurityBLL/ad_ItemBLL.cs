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
      public class ad_ItemBLL //: IDisposible
        {
            public ad_ItemBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
              _ad_ItemDAO = new ad_ItemDAO();
            }

        public ad_ItemDAO _ad_ItemDAO { get; set; }

        public int Add(ad_Item _ad_Item)
        {
            try
            {
                return _ad_ItemDAO.Add(_ad_Item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_Item> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _ad_ItemDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<ad_Item> GetAll()
        {
            try
            {
                return _ad_ItemDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_RequestionPurpose> GetAllPurpose()
        {
            try
            {
                return _ad_ItemDAO.GetAllPurpose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<ad_Item> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_ItemDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
