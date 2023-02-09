using System;
using System.Collections.Generic;
using SecurityDAL;
using SecurityEntity;

namespace SecurityBLL
{
    public class s_RoleBLL //: IDisposible
    {
        public s_RoleBLL()
        {
            //s_RoleDAO = s_Role.GetInstanceThreadSafe;
            s_RoleDAO = new s_RoleDAO();
        }

        public s_RoleDAO s_RoleDAO { get; set; }

        public List<s_Role> GetAll()
        {
            try
            {
                return s_RoleDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<s_Role> GetDynamic(string whereCondition, string orderByExpression)
        {
            try
            {
                return s_RoleDAO.GetDynamic(whereCondition, orderByExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<s_Role> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
            string sortOrder, ref int rows)
        {
            try
            {
                return s_RoleDAO.GetPaged(startRecordNo, rowPerPage, whereClause, sortColumn, sortOrder, ref rows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Add(s_Role _s_Role)
        {
            try
            {
                return s_RoleDAO.Add(_s_Role);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(s_Role _s_Role)
        {
            try
            {
                return s_RoleDAO.Update(_s_Role);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(int RoleId)
        {
            try
            {
                return s_RoleDAO.Delete(RoleId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}