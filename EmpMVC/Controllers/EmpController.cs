using EmpBL;
using EmpDTO;
using EmpMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpMVC.Controllers
{
    public class EmpController : Controller
    {
        BL blObj;
        public EmpController()
        {
            blObj = new BL();
        }
        // GET: Emp
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Fetch()
        {
            try
            {
                List<DTO> lstEmp = blObj.FetchEmpDetails();
                List<EmpFetchMVC> empMvc = new List<EmpFetchMVC>();
                foreach (var emp in lstEmp)
                {
                    EmpFetchMVC lstMvc = new EmpFetchMVC();
                    lstMvc.Ps_Number = emp.Ps_Number;
                    lstMvc.Employee_Name = emp.Employee_Name;
                    lstMvc.Email = emp.Email;
                    lstMvc.Current_skill = emp.Current_skill;
                    lstMvc.Expected_Training = emp.Expected_Training;
                    lstMvc.Expected_Training1 = emp.Expected_Training1;
                    lstMvc.Expected_Training2 = emp.Expected_Training2;
                    lstMvc.Expected_Training3 = emp.Expected_Training3;
                    empMvc.Add(lstMvc);
                }
                return View(empMvc);
            }
            catch (Exception)
            {

                return View("Error");
            }


        }
        [HttpGet]
        public ActionResult SaveEmp()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult SaveEmp(EmpFetchMVC saveObj)
        {
            try
            {
                DTO dtoObj = new DTO();
                dtoObj.Ps_Number = saveObj.Ps_Number;
                dtoObj.Employee_Name = saveObj.Employee_Name;
                dtoObj.Email = saveObj.Email;
                dtoObj.Current_skill = saveObj.Current_skill;
                dtoObj.Expected_Training = saveObj.Expected_Training;
                dtoObj.Expected_Training1 = saveObj.Expected_Training1;
                dtoObj.Expected_Training2 = saveObj.Expected_Training2;
                dtoObj.Expected_Training3 = saveObj.Expected_Training3;
                int res = blObj.SaveAllEmp(dtoObj);
                if (res == 1)
                {
                    return RedirectToAction("Fetch");
                }
                else
                {
                    return View("Error");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public ActionResult SaveLogin()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult SaveLogin(EmpFetchModel saveObj)
        {
            try
            {
                LoginDTO dtoObj = new LoginDTO();
                dtoObj.PSNumber = saveObj.PSNumber;
                dtoObj.Password = saveObj.Password;
                
                int res = blObj.SaveLogin(dtoObj);
                if (res == 1)
                {
                    return RedirectToAction("Fetch");
                }
                else
                {
                    return View("Error");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}