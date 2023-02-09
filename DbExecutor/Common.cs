using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExecutor
{
    public class Common
    {
        public FiscalYear GetFiscalFormDateAndToDate(DateTime date)
        {
            try
            {
                if (date!=DateTime.MinValue)
                {
                    FiscalYear aFiscalYear = new FiscalYear();
                    if (date.Month > 6)
                    {
                        aFiscalYear.FromDate = new DateTime(date.Year, 7, 1);
                        aFiscalYear.ToDate = new DateTime(date.Year + 1, 6, 30);
                    }
                    else
                    {
                        aFiscalYear.FromDate = new DateTime(date.Year - 1, 7, 1);
                        aFiscalYear.ToDate = new DateTime(date.Year, 6, 30);
                    }

                    return aFiscalYear;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetFiscalFormDateAndToDateString(DateTime date)
        {
            try
            {
                if (date != DateTime.MinValue)
                {
                    FiscalYear aFiscalYear = new FiscalYear();
                    if (date.Month > 6)
                    {
                        aFiscalYear.FromDate = new DateTime(date.Year, 7, 1);
                        aFiscalYear.ToDate = new DateTime(date.Year + 1, 6, 30);
                    }
                    else
                    {
                        aFiscalYear.FromDate = new DateTime(date.Year - 1, 7, 1);
                        aFiscalYear.ToDate = new DateTime(date.Year, 6, 30);
                    }

                    return aFiscalYear.FromDate.Year.ToString().Substring(2, 2) + "-" + aFiscalYear.ToDate.Year.ToString().Substring(2, 2);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
    public class FiscalYear
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
