using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
//using System.Configuration;
//using System.Text;

namespace CashManagement.Models
{
    public class DLayer
    {
        private string con = @"data source=HEARTNSOUL-PC;initial catalog=CashManagement;integrated security=true;";


        #region Connection string for Demo
        //private string con = "data source=184.168.47.19;initial catalog=hnsCashMngt; user id=CashMngt;password=Heartnsoul@357";
        //private string con = "data source=43.255.152.25;initial catalog=ph16935008596_Abacus; user id=HnsAbacus;password=HnsAbacus@357";
        #endregion

        #region Data Access Layer Work
        public string Con
        {
            get
            {

                return con;
            }
        }
        public static byte[] pImage;
        public int Int_Process(String Storp, string[] parametername, string[] parametervalue)
        {
            int a = 0;

            SqlConnection con = new SqlConnection(Con);
            SqlCommand cmd = new SqlCommand(Storp, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < parametername.Length; i++)
            {
                if (parametername[i] == "@img")
                {
                    cmd.Parameters.AddWithValue(parametername[i], pImage);
                }
                else
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                    //cmd.Parameters.Add(parametername[i], SqlDbType.Int).Direction = ParameterDirection.Output;
                }
            }
            con.Open();

            a = cmd.ExecuteNonQuery();
            con.Dispose();
            return a;
        }
        public DataSet Ds_Process(String Storp, string[] parametername, string[] parametervalue)
        {
            try
            {

                SqlConnection con = new SqlConnection(Con);
                SqlCommand cmd = new SqlCommand(Storp, con);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parametername.Length; i++)
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                }
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                da.Dispose();
                con.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                Property.erroCheck = ex.ToString();

                DataSet ds = null;
                return ds;
            }

        }
        public DataSet MyDs_Process(String Storp)
        {

            SqlConnection con = new SqlConnection(Con);
            SqlCommand cmd = new SqlCommand(Storp, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            da.Dispose();
            con.Dispose();
            return ds;

        }
        public int ExecNonQuery(String Qry)
        {
            int a = 0;

            SqlConnection con = new SqlConnection(Con);
            SqlCommand cmd = new SqlCommand(Qry, con);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            con.Open();
            a = cmd.ExecuteNonQuery();
            con.Dispose();
            return a;
        }

        #endregion



        public DataSet FetchAdminLogin_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition1, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchAdminLogin_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int InsertAdmin_Sp(AdminLogin m)
        {
            string[] paname = { "@AdminId", "@FullName", "@EmailId", "@Password", "@PhoneNo" };
            string[] pavalue = { m.AdminId, m.FullName, m.EmailId, m.Password, m.PhoneNo };
            return Int_Process("InsertAdmin_Sp", paname, pavalue);
        }

        public int InsertBranch_Sp(Branch m)
        {
            string[] paname = { "@BranchId", "@BranchName", "@Location", "@Emailid", "@Password", "@UserType" };
            string[] pavalue = { m.BranchId, m.BranchName, m.Location, m.Emailid, m.Password, m.UserType };
            return Int_Process("InsertBranch_Sp", paname, pavalue);
        }

        public DataSet FetchBranch_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition1, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchBranch_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public DataSet FetchBranchLogin_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition1, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchBranchLogin_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet FetchUser_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition1, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchUser_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertUser_Sp(User m)
        {
            string[] paname = { "@UserId", "@FirstName", "@LastName", "@Phone", "@EmailId", "@Password", "@UserType", "@BranchId" };
            string[] pavalue = { m.UserId, m.FirstName, m.LastName, m.Phone, m.EmailId, m.Password, m.UserType, m.BranchId };
            return Int_Process("InsertUser_Sp", paname, pavalue);
        }


        public DataSet FetchLogin_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition1, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchLogin_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public DataSet FetchAccountant_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition1, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchAccountant_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public int InsertAccountant_Sp(Accountant m)
        {
            string[] paname = { "@AccountantId", "@FirstName", "@LastName", "@Phone", "@EmailId", "@Password", "@UserType", "@BranchId", "@Location" };
            string[] pavalue = { m.AccountantId, m.FirstName, m.LastName, m.Phone, m.EmailId, m.Password, m.UserType, m.BranchId, m.Location };
            return Int_Process("InsertAccountant_Sp", paname, pavalue);
        }

        public int InsertChairman_Sp(Chairman m)
        {
            string[] paname = { "@ChairmanId", "@FirstName", "@LastName", "@Phone", "@EmailId", "@Password"};
            string[] pavalue = { m.ChairmanId, m.FirstName, m.LastName, m.Phone, m.EmailId, m.Password };
            return Int_Process("InsertChairman_Sp", paname, pavalue);
        }

        public DataSet FetchChairmanLogin_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition1, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchChairmanLogin_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}