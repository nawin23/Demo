using EmpDAL;
using EmpDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpBL
{
    public class BL
    {
        DAL dalObj;
        public BL()
        {
            dalObj = new DAL();
        }
        public List<DTO> FetchEmpDetails()
        {
            List<DTO> lstFetch = dalObj.GetEmpDetails();
            return lstFetch;
        }
        public int SaveAllEmp(DTO newEmp)
        {
            return dalObj.SaveEmp(newEmp);

        }
        public int SaveLogin(LoginDTO newLogin)
        {
            return dalObj.AdminLogin(newLogin);
        }
    }
}
