using CashManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashManagement.Controllers
{
    public class ChairmanController : Controller
    {
        DLayer dl = new DLayer();
        // GET: Chairman
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult MyProfile(string id)
        {
            List<Chairman> AdminLogin = new List<Chairman>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchChairmanLoginUser";

            p.Condition1 = id;

            ds = dl.FetchChairmanLogin_sp(p);

            Chairman info = new CashManagement.Models.Chairman();

            try
            {
                info = new CashManagement.Models.Chairman()
                {
                    ChairmanId = ds.Tables[1].Rows[0]["ChairmanId"].ToString(),
                    FirstName = ds.Tables[1].Rows[0]["FirstName"].ToString(),
                    LastName = ds.Tables[1].Rows[0]["LastName"].ToString(),
                    EmailId = ds.Tables[1].Rows[0]["Emailid"].ToString(),
                    Password = ds.Tables[1].Rows[0]["Password"].ToString(),
                    Phone = ds.Tables[1].Rows[0]["Phone"].ToString()
                };
            }
            catch (Exception ex)
            {

            }

            return View(info);
        }

        [HttpPost]
        public ActionResult MyProfile(Chairman m, string id)
        {
            m.EmailId = m.EmailId;
            m.Password = m.Password;
            try
            {
                if (dl.InsertChairman_Sp(m) > 0)
                {
                    TempData["MSG"] = "Data Updated Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Chairman/MyProfile/" + id);
            }
            TempData["MSG"] = "Data Updated Successfully.";
            return Redirect("/Chairman/MyProfile/" + id);
        }

        //public ActionResult Admin()
        //{

        //    List<AdminLogin> AdminList = new List<AdminLogin>();
        //    Property p = new Property();
        //    DataSet ds = new DataSet();
        //    p.OnTable = "FetchAdminDetail";

        //    ds = dl.FetchAdminLogin_sp(p);

        //    try
        //    {
        //        foreach (DataRow item in ds.Tables[0].Rows)
        //        {
        //            AdminLogin m = new AdminLogin();
        //            m.AdminId = item["AdminId"].ToString();
        //            m.FullName = item["FullName"].ToString();
        //            m.EmailId = item["EmailId"].ToString();
                  
        //            m.Password = item["Password"].ToString();
        //            m.PhoneNo = item["PhoneNo"].ToString();
        //            m.IsActive = item["IsActive"].ToString();

        //            AdminList.Add(m);
        //        }
        //        ViewBag.AdminList = AdminList;
        //    }
        //    catch (Exception ex)
        //    {

        //    }


        //    return View();
        //}

        //[ValidateInput(false)]
        //[HttpPost]
        //public ActionResult InsertAdmin(AdminLogin p)
        //{

        //    p.Password = "12345";
           
        //    try
        //    {
        //        if (dl.InsertAdmin_Sp(p) > 0)
        //        {
        //            TempData["MSG"] = "Data Added Successfully";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["MSG"] = "Something went wrong.";
        //        return Redirect("/Chairman");
        //    }
        //    TempData["MSG"] = "Data Added Successfully";
        //    return Redirect("/Chairman");
        //}

        //public JsonResult AdminStatus(string id, string status)
        //{
        //    Property a = new Property();
        //    DataSet ds = new DataSet();

        //    if (status == "True")
        //    {
        //        a.Condition1 = "False";
        //    }
        //    else
        //    {
        //        a.Condition1 = "True";
        //    }
        //    a.Condition2 = id;
        //    a.OnTable = "ChangeAdminStatus";
        //    ds = dl.FetchAdminLogin_sp(a);
        //    return Json(1, JsonRequestBehavior.AllowGet);
        //}


        //public JsonResult DeleteAdmin(string id)
        //{
        //    Property a = new Property();
        //    DataSet ds = new DataSet();
        //    a.Condition1 = id;
        //    a.OnTable = "DeleteAdmin";
        //    ds = dl.FetchAdminLogin_sp(a);
        //    return Json(1, JsonRequestBehavior.AllowGet);
        //}


        //public JsonResult getAdmin(string id)
        //{
        //    Property p = new Property();
        //    DataSet ds = new DataSet();

        //    p.OnTable = "FetchAdminDetail";

        //    if (id != null)
        //    {
        //        p.Condition1 = id;
        //    }
        //    ds = dl.FetchAdminLogin_sp(p);

        //    AdminLogin info = new CashManagement.Models.AdminLogin();

        //    try
        //    {
        //        info = new CashManagement.Models.AdminLogin()
        //        {
        //            AdminId = ds.Tables[1].Rows[0]["AdminId"].ToString(),
        //            FullName = ds.Tables[1].Rows[0]["FullName"].ToString(),
        //            EmailId = ds.Tables[1].Rows[0]["EmailId"].ToString(),
        //            PhoneNo = ds.Tables[1].Rows[0]["PhoneNo"].ToString()
        //        };
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return Json(info, JsonRequestBehavior.AllowGet);
        //}




    }
}