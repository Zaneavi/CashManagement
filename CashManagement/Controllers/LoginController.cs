using CashManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashManagement.Controllers
{
    public class LoginController : Controller
    {
        DLayer dl = new DLayer();
        // GET: BranchLogin
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(Branch a)
        {

            Property p = new Property();
            DataSet ds = new DataSet();

            p.Condition1 = a.Emailid;
            p.Condition2 = a.Password;
            p.OnTable = "Checklogin";
            ds = dl.FetchLogin_sp(p);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    HttpCookie cashCookie = Request.Cookies["cash"];
                    String Status = ds.Tables[0].Rows[0]["IsActive"].ToString();
                    String UserId = ds.Tables[0].Rows[0]["UserId"].ToString();
                    String UserType = ds.Tables[0].Rows[0]["UserType"].ToString();
                    if (Status == "True" && UserType == "Branch")
                    {
                        cashCookie = new HttpCookie("cashBranch");
                        cashCookie["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                        cashCookie["UserId"] = ds.Tables[0].Rows[0]["UserId"].ToString();
                        cashCookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(cashCookie);
                        return RedirectToAction("Dashboard", "Branch");
                    }
                    else if (Status == "True" && UserType == "User")
                    {
                        cashCookie = new HttpCookie("cashUser");
                        cashCookie["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                        cashCookie["UserId"] = ds.Tables[0].Rows[0]["UserId"].ToString();
                        cashCookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(cashCookie);
                        return RedirectToAction("Index", "User");
                    }


                    else if (Status == "True" && UserType == "Accountant")
                    {
                        cashCookie = new HttpCookie("cashAccountant");
                        cashCookie["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                        cashCookie["UserId"] = ds.Tables[0].Rows[0]["UserId"].ToString();
                        cashCookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(cashCookie);
                        return RedirectToAction("Index", "Accountant");
                    }



                    else if (Status == "True" && UserType == "DataOperator")
                    {
                        cashCookie = new HttpCookie("cashDataOperator");
                        cashCookie["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                        cashCookie["UserId"] = ds.Tables[0].Rows[0]["UserId"].ToString();
                        cashCookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(cashCookie);
                        return RedirectToAction("Index", "DataOperator");
                    }





                    else
                    {
                        TempData["MSGlogin"] = "Email-id / Password is incorrect";
                    }
                    
                }
                else
                {
                    TempData["MSGlogin"] = "Email-id / Password is incorrect";
                }
            }
            catch (Exception ex)
            {
                TempData["MSGlogin"] = "Email-id / Password is incorrect or account not active!";
            }

            TempData["MSG"] = "Email-id / Password is incorrect or account not active!";

            return RedirectToAction("Index", "Login");
        }

        public ActionResult BranchLogout()
        {
            Session.Abandon();
            Session.Clear();
            HttpCookie cashBranchCookie = Request.Cookies["cashBranch"];

            if (cashBranchCookie != null)
            {
                cashBranchCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cashBranchCookie);
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            return Redirect("/Login");
        }


        public ActionResult AccountantLogout()
        {
            Session.Abandon();
            Session.Clear();
            HttpCookie cashCookie = Request.Cookies["cashAccountant"];

            if (cashCookie != null)
            {
                cashCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cashCookie);
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            return Redirect("/Login");
        }

        public ActionResult UserLogout()
        {
            Session.Abandon();
            Session.Clear();
            HttpCookie cashCookie = Request.Cookies["cashUser"];

            if (cashCookie != null)
            {
                cashCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cashCookie);
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            return Redirect("/Login");
        }

        public ActionResult OperatorLogout()
        {
            Session.Abandon();
            Session.Clear();
            HttpCookie cashCookie = Request.Cookies["cashDataOperator"];

            if (cashCookie != null)
            {
                cashCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cashCookie);
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            return Redirect("/Login");
        }

       
     


    }
}