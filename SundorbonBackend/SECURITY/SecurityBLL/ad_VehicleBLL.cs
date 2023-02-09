using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtrialDAL;
using XtrialEntity;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_VehicleBLL
    {
        public ad_VehicleBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_VehicleDAO = new ad_VehicleDAO();
        }

        public ad_VehicleDAO _ad_VehicleDAO { get; set; }

        public int Add(ad_Vehicle _ad_Vehicle)
        {
            try
            {
                return _ad_VehicleDAO.Post(_ad_Vehicle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_Vehicle> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _ad_VehicleDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_Vehicle> GetAllActive()
        {
            try
            {
                return _ad_VehicleDAO.GetAllActive();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_Vehicle> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_VehicleDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
