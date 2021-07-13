using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashManagement.Models
{
    public class Property
    {
        private string staticSMTPHOST = "#";

        public string StaticSMTPHOST
        {
            get
            {
                return staticSMTPHOST;
            }
        }

        public int staticSMTPPort = 25;
        public int StaticSMTPPort
        {
            get
            {
                return staticSMTPPort;
            }
        }
        public static string erroCheck { get; set; }
        private string staticCredentialEmail = "#";
        // private string staticCredentialEmail = "developer@gowebbi.com";
        public string StaticCredentialEmail
        {
            get
            {
                return staticCredentialEmail;
            }
        }

        //private string staticCredentialPass = "Gowebbi@123";
        private string staticCredentialPass = "#";

        public string StaticCredentialPass
        {
            get
            {
                return staticCredentialPass;
            }
        }

        public string Condition1 { get; set; }
        public string Condition2 { get; set; }
        public string Condition3 { get; set; }
        public string Condition4 { get; set; }
        public string Condition5 { get; set; }
        public string Condition6 { get; set; }
        public string Condition7 { get; set; }
        public string Condition8 { get; set; }
        public string Condition9 { get; set; }
        public string OnTable { get; set; }
    }
    #region AdminLogin
    public class AdminLogin
    {
        public string AdminId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public string IsActive { get; set; }
       
    }
    #endregion

    public class Branch
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string Location { get; set; }
        public string Emailid { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string RegisteredOn { get; set; }
        public string IsActive { get; set; }

    }

    public class User
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Remote("IsNumberAlreadySigned1", "Branch", HttpMethod = "POST", ErrorMessage = "Number Already exists.")]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Enter Email Address")]
        [Remote("IsEmailAlreadySigned1", "Branch", HttpMethod = "POST", ErrorMessage = "Email Already exists.")]
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string BranchId { get; set; }
        public string RegisteredOn { get; set; }
        public string IsActive { get; set; }

    }


    public class Accountant
    {
        public string AccountantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string BranchId { get; set; }
        public string RegisteredOn { get; set; }
        public string IsActive { get; set; }

    }

    public class Chairman
    {
        public string ChairmanId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string RegisteredOn { get; set; }
        public string IsActive { get; set; }

    }





}