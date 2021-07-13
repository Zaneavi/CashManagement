using CashManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashManagement.Controllers
{
    public class BranchController : Controller
    {
        DLayer dl = new DLayer();
        // GET: Branch

        public ActionResult Dashboard()
        {

            return View();
        }


        public ActionResult Index()
        {
            List<Branch> BranchList = new List<Branch>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchBranchDetail";

            ds = dl.FetchBranch_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Branch m = new Branch();
                    m.BranchId = item["BranchId"].ToString();
                    m.BranchName = item["BranchName"].ToString();
                    m.Location = item["Location"].ToString();
                    m.Emailid = item["Emailid"].ToString();
                    m.Password = item["Password"].ToString();
                    m.RegisteredOn = item["RegisteredOn"].ToString();
                    m.IsActive = item["IsActive"].ToString();

                    BranchList.Add(m);
                }
                ViewBag.BranchList = BranchList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult InsertBranch(Branch p)
        {
            
            p.Password = "12345";
            p.UserType = "Branch";
            try
            {
                if (dl.InsertBranch_Sp(p) > 0)
                {
                    TempData["MSG"] = "Data Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Branch");
            }
            TempData["MSG"] = "Data Added Successfully";
            return Redirect("/Branch");
        }

        public JsonResult BranchStatus(string id, string status)
        {
            Property a = new Property();
            DataSet ds = new DataSet();

            if (status == "True")
            {
                a.Condition1 = "False";
            }
            else
            {
                a.Condition1 = "True";
            }
            a.Condition2 = id;
            a.OnTable = "ChangeBranchStatus";
            ds = dl.FetchBranch_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteBranch(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteBranch";
            ds = dl.FetchBranch_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }


        public JsonResult getbranch(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchBranchDetail";

            if (id != null)
            {
                p.Condition1 = id;
            }
            ds = dl.FetchBranch_sp(p);

            Branch info = new CashManagement.Models.Branch();

            try
            {
                info = new CashManagement.Models.Branch()
                {
                    BranchId = ds.Tables[1].Rows[0]["BranchId"].ToString(),
                    BranchName = ds.Tables[1].Rows[0]["BranchName"].ToString(),
                    Location = ds.Tables[1].Rows[0]["Location"].ToString(),
                    Emailid = ds.Tables[1].Rows[0]["Emailid"].ToString()
                };
            }
            catch (Exception ex)
            {

            }
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public ActionResult User()
        {
            HttpCookie cashCookie = Request.Cookies["cashBranch"];

            List<User> UserList = new List<User>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchUserDetail";
            p.Condition2= cashCookie.Values["UserId"];
            ds = dl.FetchUser_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    User m = new User();
                    m.UserId = item["UserId"].ToString();
                    m.FirstName = item["FirstName"].ToString();
                    m.LastName = item["LastName"].ToString();
                    m.Phone = item["Phone"].ToString();
                    m.EmailId = item["EmailId"].ToString();
                    m.Password = item["Password"].ToString();
                    m.UserType = item["UserType"].ToString();
                    m.BranchId = item["BranchId"].ToString();
                    m.RegisteredOn = item["RegisteredOn"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    UserList.Add(m);
                }
                ViewBag.UserList = UserList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult InsertUser(User p)
        {
            
            HttpCookie cashBranchCookie = Request.Cookies["cashBranchCookie"];


            p.BranchId= cashBranchCookie.Values["BranchId"];
            p.UserType = "User";
            p.Password = "12345";

            try
            {
                if (dl.InsertUser_Sp(p) > 0)
                {
                    TempData["MSG"] = "Data Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Branch/User");
            }
            TempData["MSG"] = "Data Added Successfully";
            return Redirect("/Branch/User");
        }


        public JsonResult getuser(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchUserDetail";

            if (id != null)
            {
                p.Condition1 = id;
            }
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
                    EmailId = ds.Tables[1].Rows[0]["EmailId"].ToString()
                };
            }
            catch (Exception ex)
            {

            }
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UserStatus(string id, string status)
        {
            Property a = new Property();
            DataSet ds = new DataSet();

            if (status == "True")
            {
                a.Condition1 = "False";
            }
            else
            {
                a.Condition1 = "True";
            }
            a.Condition2 = id;
            a.OnTable = "ChangeUserStatus";
            ds = dl.FetchUser_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteUser(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteUser";
            ds = dl.FetchUser_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        #region validation

        [HttpPost]
        public JsonResult IsEmailAlreadySigned1(string EmailId)
        {

            return Json(CheckEmailAvailability1(EmailId));

        }
        public bool CheckEmailAvailability1(string EmailId)
        {

            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = EmailId;
            a.OnTable = "Checkidexists";
            ds = dl.FetchUser_sp(a);

            User SeachData = new CashManagement.Models.User();
            bool status;

            try
            {
                SeachData = new CashManagement.Models.User()
                {
                    UserId = ds.Tables[0].Rows[0]["UserId"].ToString(),
                    EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString()
                };

                status = false;


            }
            catch (Exception ex)
            {
                status = true;
            }
            return status;
        }



        [HttpPost]
        public JsonResult IsNumberAlreadySigned1(string Phone)
        {

            return Json(CheckNumberAvailability1(Phone));

        }
        public bool CheckNumberAvailability1(string Phone)
        {

            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition2 = Phone;
            a.OnTable = "Checkidexists";
            ds = dl.FetchUser_sp(a);

            User SeachData = new CashManagement.Models.User();
            bool status;

            try
            {
                SeachData = new CashManagement.Models.User()
                {
                    UserId = ds.Tables[1].Rows[0]["UserId"].ToString(),
                    Phone = ds.Tables[1].Rows[0]["Phone"].ToString()
                };

                status = false;


            }
            catch (Exception ex)
            {
                status = true;
            }
            return status;
        }





        #endregion


        #region MyProfile

        public ActionResult MyProfile(string id)
        {
            List<Branch> BranchLogin = new List<Branch>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchBranchLoginUser";

            p.Condition1 = id;

            ds = dl.FetchBranchLogin_sp(p);

            Branch info = new CashManagement.Models.Branch();

            try
            {
                info = new CashManagement.Models.Branch()
                {
                    BranchId = ds.Tables[1].Rows[0]["BranchId"].ToString(),
                    BranchName = ds.Tables[1].Rows[0]["BranchName"].ToString(),
                    Location = ds.Tables[1].Rows[0]["Location"].ToString(),
                    Emailid = ds.Tables[1].Rows[0]["Emailid"].ToString(),
                    Password = ds.Tables[1].Rows[0]["Password"].ToString()
                };
            }
            catch (Exception ex)
            {

            }

            return View(info);
        }

        [HttpPost]
        public ActionResult MyProfile(Branch m, string id)
        {
            m.Emailid = m.Emailid;
            m.Password = m.Password;
            try
            {
                if (dl.InsertBranch_Sp(m) > 0)
                {
                    TempData["MSG"] = "Data Updated Successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Branch/MyProfile/" + id);
            }
            TempData["MSG"] = "Data Updated Successfully.";
            return Redirect("/Branch/MyProfile/" + id);
        }


        #endregion




        #region Accountant


        public ActionResult Accountant()
        {
            HttpCookie cashCookie = Request.Cookies["cashBranch"];

            List<Accountant> AccountantList = new List<Accountant>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchAccountantDetail";
            p.Condition2 = cashCookie.Values["UserId"];
            ds = dl.FetchAccountant_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Accountant m = new Accountant();
                    m.AccountantId = item["AccountantId"].ToString();
                    m.FirstName = item["FirstName"].ToString();
                    m.LastName = item["LastName"].ToString();
                    m.Phone = item["Phone"].ToString();
                    m.Location = item["Location"].ToString();
                    m.EmailId = item["EmailId"].ToString();
                    m.Password = item["Password"].ToString();
                    m.UserType = item["UserType"].ToString();
                    m.BranchId = item["BranchId"].ToString();
                    m.RegisteredOn = item["RegisteredOn"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    AccountantList.Add(m);
                }
                ViewBag.AccountantList = AccountantList;
            }
            catch (Exception ex)
            {

            }
            return View();
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult InsertAccountant(Accountant p)
        {

            HttpCookie cashCookie = Request.Cookies["cashBranch"];
            
            p.BranchId = cashCookie.Values["UserId"];
            p.UserType = "Accountant";
            p.Password = "12345";

            try
            {
                if (dl.InsertAccountant_Sp(p) > 0)
                {
                    TempData["MSG"] = "Data Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Branch/Accountant");
            }
            TempData["MSG"] = "Data Added Successfully";
            return Redirect("/Branch/Accountant");
        }


        public JsonResult getAccountant(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();

            p.OnTable = "FetchAccountantDetail";

            if (id != null)
            {
                p.Condition1 = id;
            }
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
                    Location = ds.Tables[1].Rows[0]["Location"].ToString(),
                    EmailId = ds.Tables[1].Rows[0]["EmailId"].ToString()
                };
            }
            catch (Exception ex)
            {

            }
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AccountantStatus(string id, string status)
        {
            Property a = new Property();
            DataSet ds = new DataSet();

            if (status == "True")
            {
                a.Condition1 = "False";
            }
            else
            {
                a.Condition1 = "True";
            }
            a.Condition2 = id;
            a.OnTable = "ChangeAccountantStatus";
            ds = dl.FetchAccountant_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteAccountant(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteAccountant";
            ds = dl.FetchAccountant_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }


        #endregion












    }
}