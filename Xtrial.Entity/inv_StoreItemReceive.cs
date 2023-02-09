using System;
using System.Text;

namespace XtrialEntity
{
	public class inv_StoreItemReceive
	{
		public string Number { get; set; }
		public string StockReceiveDate { get; set; }
		public Int16 StockReceivedFrom { get; set; }
		public Int32 ReceivedByUserId { get; set; }
		public string PurchaseBillOrRequisitionSlipNo { get; set; }
		public Int32? CounterId { get; set; }
		public string Remarks { get; set; }
		public Int32? CreatorId { get; set; }
		public DateTime? CreationDate { get; set; }
		public Int32? UpdatorId { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
