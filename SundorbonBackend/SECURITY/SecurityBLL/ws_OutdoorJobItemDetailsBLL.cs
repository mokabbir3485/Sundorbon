using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ws_OutdoorJobItemDetailsBLL
    {
        public ws_OutdoorJobItemDetailsBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            ws_OutdoorJobItemDetailsDAO = new ws_OutdoorJobItemDetailsDAO();
        }

        public ws_OutdoorJobItemDetailsDAO ws_OutdoorJobItemDetailsDAO { get; set; }
       
        public List<ws_OutdoorJobItemDetails> GetAllByJobNumber(string Number)
        {
            try
            {
                return ws_OutdoorJobItemDetailsDAO.GetByJobNumber(Number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Add(ws_OutdoorJobItemDetails _ws_OutdoorJobItemDetails, string transactionType)
        {
            try
            {
                return ws_OutdoorJobItemDetailsDAO.Post(_ws_OutdoorJobItemDetails, transactionType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
