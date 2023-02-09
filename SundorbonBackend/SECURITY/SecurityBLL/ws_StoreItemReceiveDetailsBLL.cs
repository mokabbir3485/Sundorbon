using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ws_StoreItemReceiveDetailsBLL
    {
        public ws_StoreItemReceiveDetailsBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ws_StoreItemReceiveDetailsDAO = new ws_StoreItemReceiveDetailDAO();
        }

        public ws_StoreItemReceiveDetailDAO _ws_StoreItemReceiveDetailsDAO { get; set; }


        public string Add(ws_StoreItemReceiveDetails _ws_StoreItemReceiveDetails)
        {
            try
            {
                return _ws_StoreItemReceiveDetailsDAO.Post(_ws_StoreItemReceiveDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
