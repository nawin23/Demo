using EmpDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDAL
{
    public class DAL
    {
        SqlConnection conObj;
        SqlCommand cmdObj;
        StepUpContext stepUpContext;
        public DAL()
        {
            conObj = new SqlConnection(ConfigurationManager.ConnectionStrings["StepUPstr"].ConnectionString);
            stepUpContext = new StepUpContext();
        }
        public List<DTO> GetEmpDetails()
        {
            try
            {
                var res = stepUpContext.Employees.ToList();
                List<DTO> lstEmp = new List<DTO>();
                foreach (var emp in res)
                {
                    lstEmp.Add(new DTO
                    {
                        Ps_Number = Convert.ToInt32(emp.ps_no),
                        Employee_Name = emp.employee_name,
                        Email = emp.email_id,
                        Current_skill = emp.current_skills,
                        Expected_Training = emp.excepted_training,
                        Expected_Training1 = emp.excepted_1,
                        Expected_Training2 = emp.excepted_2,
                        Expected_Training3 = emp.excepted_3,



                    });

                }
                return lstEmp;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public int SaveEmp(DTO newEmp)
        {
            try
            {
                cmdObj = new SqlCommand();
                cmdObj.CommandText = @"uspAddEmployee";
                cmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                cmdObj.Connection = conObj;
                cmdObj.Parameters.AddWithValue(@"ps_no", newEmp.Ps_Number);
                cmdObj.Parameters.AddWithValue(@"employee_name", newEmp.Employee_Name);
                cmdObj.Parameters.AddWithValue(@"email_id", newEmp.Email);
                cmdObj.Parameters.AddWithValue(@"current_skill", newEmp.Current_skill);
                cmdObj.Parameters.AddWithValue(@"expected_training", newEmp.Expected_Training);
                cmdObj.Parameters.AddWithValue(@"expected_1", newEmp.Expected_Training1);
                cmdObj.Parameters.AddWithValue(@"expected_2", newEmp.Expected_Training2);
                cmdObj.Parameters.AddWithValue(@"expected_3", newEmp.Expected_Training3);
                SqlParameter retObj = new SqlParameter();
                retObj.Direction = ParameterDirection.ReturnValue;
                retObj.SqlDbType = SqlDbType.Int;
                cmdObj.Parameters.Add(retObj);
                conObj.Open();
                cmdObj.ExecuteNonQuery();
                return Convert.ToInt32(retObj.Value);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public int AdminLogin(LoginDTO newLogin)
        {
            try
            {
                cmdObj = new SqlCommand();
                cmdObj.CommandText = @"uspLogin";
                cmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                cmdObj.Connection = conObj;
                cmdObj.Parameters.AddWithValue(@"psnumber", newLogin.PSNumber);
                cmdObj.Parameters.AddWithValue(@"password", newLogin.Password);
                SqlParameter retObj = new SqlParameter();
                retObj.Direction = ParameterDirection.ReturnValue;
                retObj.SqlDbType = SqlDbType.Int;
                cmdObj.Parameters.Add(retObj);
                conObj.Open();
                cmdObj.ExecuteNonQuery();
                return Convert.ToInt32(retObj.Value);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

