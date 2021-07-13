using CashManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashManagement.Controllers
{
    public class UserController : Controller
    {
        DLayer dl = new DLayer();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult MyProfile(string id)
        {
            List<User> AdminLogin = new List<User>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchLoginUser";

            p.Condition1 = id;

            ds = dl.FetchUser_sp(p);

            User info = new CashManagement.Models.User();

            try
            {
                info = new CashManagement.Models.User()
                {
                    UserId = ds.Tables[1].Rows[0]["UserId"].ToString(),
                    FirstName = ds.Tables[1].Rows[0]["FirstName"].ToString(),
                    LastName = ds.Tables[1].Rows[0]["LastName"].ToString(),
                    Phone = ds.Tables[1].Rows[0]["Phone"].ToString(),
                    EmailId = ds.Tables[1].Rows[0]["EmailId"].ToString(),
                    BranchId = ds.Tables[1].Rows[0]["BranchId"].ToString(),
                    Password = ds.Tables[1].Rows[0]["Password"].ToString()
                };
            }
            catch (Exception ex)
            {

            }

            return View(info);
        }

        [HttpPost]
        public ActionResult MyProfile(User m, string id)
        {
            m.UserType = "User";
            m.EmailId = m.EmailId;
            m.Password = m.Password;
            try
            {
                if (dl.InsertUser_Sp(m) > 0)
                {
                    TempData["MSG"] = "Data Updated Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/User/MyProfile/" + id);
            }
            TempData["MSG"] = "Data Updated Successfully.";
            return Redirect("/User/MyProfile/" + id);
        }






    }
}