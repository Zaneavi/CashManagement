using CashManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashManagement.Controllers
{
    public class AccountantController : Controller
    {
        DLayer dl = new DLayer();
        // GET: Accountant
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult MyProfile(string id)
        {
            List<Accountant> AdminLogin = new List<Accountant>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchLoginUser";

            p.Condition1 = id;

            ds = dl.FetchAccountant_sp(p);

            Accountant info = new CashManagement.Models.Accountant();

            try
            {
                info = new CashManagement.Models.Accountant()
                {
                    AccountantId = ds.Tables[1].Rows[0]["AccountantId"].ToString(),
                    FirstName = ds.Tables[1].Rows[0]["FirstName"].ToString(),
                    LastName = ds.Tables[1].Rows[0]["LastName"].ToString(),
                    Phone = ds.Tables[1].Rows[0]["Phone"].ToString(),
                    EmailId = ds.Tables[1].Rows[0]["EmailId"].ToString(),
                    BranchId = ds.Tables[1].Rows[0]["BranchId"].ToString(),
                    Location = ds.Tables[1].Rows[0]["Location"].ToString(),
                    Password = ds.Tables[1].Rows[0]["Password"].ToString()
                };
            }
            catch (Exception ex)
            {

            }

            return View(info);
        }

        [HttpPost]
        public ActionResult MyProfile(Accountant m, string id)
        {
            m.UserType = "Accountant";
            m.EmailId = m.EmailId;
            m.Password = m.Password;
            try
            {
                if (dl.InsertAccountant_Sp(m) > 0)
                {
                    TempData["MSG"] = "Data Updated Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Accountant/MyProfile/" + id);
            }
            TempData["MSG"] = "Data Updated Successfully.";
            return Redirect("/Accountant/MyProfile/" + id);
        }



    }
}