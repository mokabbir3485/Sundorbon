using Sundorbon.Backend.SECURITY.SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class ad_VehicleGroupBLL
    {
        public ad_VehicleGroupBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ad_VehicleGroupDAO = new ad_VehicleGroupDAO();
        }

        public ad_VehicleGroupDAO _ad_VehicleGroupDAO { get; set; }

        public int Add(ad_VehicleGroup _ad_VehicleGroup)
        {
            try
            {
                return _ad_VehicleGroupDAO.Add(_ad_VehicleGroup);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_VehicleGroup> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return _ad_VehicleGroupDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ad_VehicleGroup> GetAll()
        {
            try
            {
                return _ad_VehicleGroupDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ad_VehicleGroup> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
         string sortOrder, ref int rows)
        {
            try
            {
                return _ad_VehicleGroupDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
