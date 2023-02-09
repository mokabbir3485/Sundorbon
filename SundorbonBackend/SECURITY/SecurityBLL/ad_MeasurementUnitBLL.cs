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
      public class ad_MeasurementUnitBLL //: IDisposible
        {
            public ad_MeasurementUnitBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_MeasurementUnitDAO = new ad_MeasurementUnitDAO();
            }

        public ad_MeasurementUnitDAO _ad_MeasurementUnitDAO { get; set; }

        public int Add(ad_MeasurementUnit _ad_MeasurementUnit)
        {
            try
            {
                return _ad_MeasurementUnitDAO.Add(_ad_MeasurementUnit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_MeasurementUnit> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _ad_MeasurementUnitDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_MeasurementUnit> GetAll()
        {
            try
            {
                return _ad_MeasurementUnitDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_MeasurementUnit> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_MeasurementUnitDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
