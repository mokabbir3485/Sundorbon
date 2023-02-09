using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtrialDAL;
using XtrialEntity;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_RecordSerialBLL
    {
        public ad_RecordSerialBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_RecordSerialDAO = new ad_RecordSerialDAO();
        }

        public ad_RecordSerialDAO _ad_RecordSerialDAO { get; set; }
        public List<ad_RecordSerial> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_RecordSerialDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add(ad_RecordSerial _ad_RecordSerial)
        {
            try
            {
                return _ad_RecordSerialDAO.Post(_ad_RecordSerial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
