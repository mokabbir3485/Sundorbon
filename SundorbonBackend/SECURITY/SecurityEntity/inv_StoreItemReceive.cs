using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityEntity
{
    public class inv_StoreItemReceive
    {
        public string Number { get; set; }
        public DateTime StockReceiveDate { get; set; }
        public int StockReceivedFrom { get; set; }
        public int ReceivedByUserId { get; set; }
        public string PurchaseBillOrRequisitionSlipNo { get; set; }
        public int CounterId { get; set; }
        public string Remarks { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public int UpdatorId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string TransactionType { get; set; }
    }
}
