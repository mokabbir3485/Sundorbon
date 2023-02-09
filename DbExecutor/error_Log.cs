using System;
using System.Text;

namespace DbExecutor
{
	public class error_Log
	{
		public Int64  ErrorId { get; set; }
		public DateTime  ErrorDate { get; set; }
		public string  ErrorSide { get; set; }
		public string  ErrorMessage { get; set; }
		public string  ErrorType { get; set; }
		public string  FileName { get; set; }
		public string  IpAddress { get; set; }
		public Int32  UserId { get; set; }
		public bool  IsSolved { get; set; }
	}
}
