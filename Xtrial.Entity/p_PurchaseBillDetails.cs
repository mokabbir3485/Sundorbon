using System;
using System.Text;

namespace XtrialEntity
{
	public class p_PurchaseBillDetails
	{
		public Int32 Id { get; set; }
		public string PuchaseBillNumber { get; set; }
		public Int32 ItemId { get; set; }
		public Decimal Qty { get; set; }
		public Decimal UnitPrice { get; set; }
		public Decimal Amount { get; set; }
		public Decimal Discount { get; set; }
		public Decimal AfterDiscount { get; set; }
		public Decimal AIT { get; set; }
		public Decimal SD { get; set; }
		public Decimal VAT { get; set; }
	}
}
