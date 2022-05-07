

using ERPAPI.Entities;
using ERPDAL.Interface;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace ERPDAL.Implementation
{
    public class MembersDAL : IMembersDAL
    {

        public User AuthenticateMember(string user, string password)
        {

            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("SP_ERP_Valid_Member", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("p_username", OracleDbType.Varchar2).Value = user;
                        command.Parameters.Add("p_password", OracleDbType.Varchar2).Value = password;
                        // command.Parameters["member_cursor"].Direction = ParameterDirection.Output;
                        command.Parameters.Add("member_cursor", OracleDbType.RefCursor, 120);
                        command.Parameters["member_cursor"].Direction = ParameterDirection.Output;
                        connection.Open();
                        //command.ExecuteNonQuery();

                        OracleDataAdapter da = new OracleDataAdapter(command);

                        // create the data set
                        DataSet ds = new DataSet();

                        // fill the data set
                        da.Fill(ds);
                        //string SomeOutVar = command.Parameters["member_cursor"].Value.ToString();


                        List<User> lst = ConvertToUserObject(ds.Tables[0]);



                        return lst.FirstOrDefault();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public List<User> ConvertToUserObject(DataTable dt,bool newcall=false)
        {
            List<User> lstUsers = new List<User>();

            foreach (DataRow dr in dt.Rows)
            {
                User user = new User();
                user.RoleType = Convert.ToInt32(dr["ROLETYPE"]);
                user.Id = Convert.ToInt64(dr["MEMBERID"]);
                user.FirstName = Convert.ToString(dr["FIRSTNAME"]);

                user.DepartmentId = Convert.ToInt32(dr["DEPARTMENTID"]);
                user.Email = Convert.ToString(dr["EMAIL"]);

                user.UserName = Convert.ToString(dr["USERNAME"]);
                user.Location = Convert.ToString(dr["LOCATION"]);
                // user.pass = dr["PASSWORD"];
                user.IsGKPUser = Convert.ToBoolean(Convert.ToInt16(dr["ISGKPUSER"]));

                user.IsAccountManager = Convert.ToBoolean(Convert.ToInt16(dr["ISACCOUNTMANAGER"]));
                user.AccountManager = Convert.ToInt64(dr["ACCOUNTMANAGER"]);
                //user.IsDeeleted = Convert.ToBoolean(Convert.ToInt16(dr["ISDELETE"]));
                user.DateCreated = Convert.ToDateTime(dr["DATECREATED"]);
                // user.DateModified = Convert.ToDateTime( dr["DATEMODIFIED"]);
                if(newcall)
                {
                    user.DepartmentName= Convert.ToString(dr["DEPARTMENTNAME"]);
                    user.RoleName = Convert.ToString(dr["ROLENAME"]);
                    user.AccountManagerName = Convert.ToString(dr["AccountManagerName"]);
                }

                lstUsers.Add(user);

            }

            return lstUsers;
        }

        public bool AddMember(User user)
        {
            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("SP_ERP_Ins_Member", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("p_firstname", OracleDbType.Varchar2).Value = user.FirstName;
                        command.Parameters.Add("p_lastname", OracleDbType.Varchar2).Value = user.LastName;
                        command.Parameters.Add("p_departmentid", OracleDbType.Int32).Value = user.DepartmentId;
                        command.Parameters.Add("p_roletype", OracleDbType.Int32).Value = user.RoleType;

                        command.Parameters.Add("p_email", OracleDbType.Varchar2).Value = user.Email;
                        command.Parameters.Add("p_username", OracleDbType.Varchar2).Value = user.UserName;
                        command.Parameters.Add("p_password", OracleDbType.Varchar2).Value = user.Password;
                        command.Parameters.Add("p_location", OracleDbType.Varchar2).Value = user.Location;
                        command.Parameters.Add("p_isgkpuser", OracleDbType.Char).Value = (user.IsGKPUser) ? "1" : "0";
                        command.Parameters.Add("p_isaccountmanager", OracleDbType.Char).Value = (user.IsAccountManager) ? "1" : "0";
                        command.Parameters.Add("p_accountmanager", OracleDbType.Int64).Value = user.AccountManager;


                        connection.Open();
                        command.ExecuteNonQuery();





                        return true;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateMember(User user)
        {
            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("SP_ERP_Upd_Member", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.Add("p_memberid", OracleDbType.Int64).Value = user.Id;
                        command.Parameters.Add("p_firstname", OracleDbType.Varchar2).Value = user.FirstName;
                        command.Parameters.Add("p_lastname", OracleDbType.Varchar2).Value = user.LastName;
                        command.Parameters.Add("p_departmentid", OracleDbType.Int32).Value = user.DepartmentId;
                        command.Parameters.Add("p_roletype", OracleDbType.Int32).Value = user.RoleType;

                        command.Parameters.Add("p_email", OracleDbType.Varchar2).Value = user.Email;
                        command.Parameters.Add("p_username", OracleDbType.Varchar2).Value = user.UserName;
                        command.Parameters.Add("p_password", OracleDbType.Varchar2).Value = user.Password;
                        command.Parameters.Add("p_location", OracleDbType.Varchar2).Value = user.Location;
                        command.Parameters.Add("p_isgkpuser", OracleDbType.Char).Value = (user.IsGKPUser) ? "1" : "0";
                        command.Parameters.Add("p_isaccountmanager", OracleDbType.Char).Value = (user.IsAccountManager) ? "1" : "0";
                        command.Parameters.Add("p_accountmanager", OracleDbType.Int64).Value = user.AccountManager;


                        connection.Open();
                        command.ExecuteNonQuery();





                        return true;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteMember(long id)
        {
            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("sp_erp_del_member", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.Add("p_memberid", OracleDbType.Int64).Value = id;

                        command.Parameters.Add("p_isdel", OracleDbType.Char).Value = "1";

                        connection.Open();
                        command.ExecuteNonQuery();





                        return true;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<User> GetAllTeammembers()
        {


            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("USP_ERP_GETALLMEMBERS", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                      
                        command.Parameters.Add("member_cursor", OracleDbType.RefCursor, 120);
                        command.Parameters["member_cursor"].Direction = ParameterDirection.Output;
                        connection.Open();
                        //command.ExecuteNonQuery();

                        OracleDataAdapter da = new OracleDataAdapter(command);

                        // create the data set
                        DataSet ds = new DataSet();

                        // fill the data set
                        da.Fill(ds);
                        //string SomeOutVar = command.Parameters["member_cursor"].Value.ToString();


                        List<User> lst = ConvertToUserObject(ds.Tables[0],true);



                        return lst;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<User> GetAllTeammembersByRole(int RoleId)
        {


            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("USP_ERP_GETALLMEMBERSBYROLE", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_roletype", OracleDbType.Int32).Value = RoleId;

                        command.Parameters.Add("member_cursor", OracleDbType.RefCursor, 120);
                        command.Parameters["member_cursor"].Direction = ParameterDirection.Output;
                        connection.Open();
                        //command.ExecuteNonQuery();

                        OracleDataAdapter da = new OracleDataAdapter(command);

                        // create the data set
                        DataSet ds = new DataSet();

                        // fill the data set
                        da.Fill(ds);
                        //string SomeOutVar = command.Parameters["member_cursor"].Value.ToString();


                        List<User> lst = ConvertToUserObject(ds.Tables[0]);



                        return lst;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<User> GetAllTeammembersByDepartment(int DepartmentId)
        {


            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("USP_ERP_GETALLMEMBERSBYDEP", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("p_departmentid", OracleDbType.Int32).Value = DepartmentId;

                        command.Parameters.Add("member_cursor", OracleDbType.RefCursor, 120);
                        command.Parameters["member_cursor"].Direction = ParameterDirection.Output;
                        connection.Open();
                        //command.ExecuteNonQuery();

                        OracleDataAdapter da = new OracleDataAdapter(command);

                        // create the data set
                        DataSet ds = new DataSet();

                        // fill the data set
                        da.Fill(ds);
                        //string SomeOutVar = command.Parameters["member_cursor"].Value.ToString();


                        List<User> lst = ConvertToUserObject(ds.Tables[0]);



                        return lst;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<User> GetAllAccountManager()
        {


            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("USP_ERP_GETALLACCOUNTMANAGERS", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("member_cursor", OracleDbType.RefCursor, 120);
                        command.Parameters["member_cursor"].Direction = ParameterDirection.Output;
                        connection.Open();
                        //command.ExecuteNonQuery();

                        OracleDataAdapter da = new OracleDataAdapter(command);

                        // create the data set
                        DataSet ds = new DataSet();

                        // fill the data set
                        da.Fill(ds);
                        //string SomeOutVar = command.Parameters["member_cursor"].Value.ToString();


                        List<User> lst = ConvertToUserObject(ds.Tables[0]);



                        return lst;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public List<User> GetAllTeammembersById(long id)
        {


            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("USP_ERP_GETALLMEMBERSBYID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("p_departmentid", OracleDbType.Int64).Value = id;
                        command.Parameters.Add("member_cursor", OracleDbType.RefCursor, 120);
                        command.Parameters["member_cursor"].Direction = ParameterDirection.Output;
                        connection.Open();
                        //command.ExecuteNonQuery();

                        OracleDataAdapter da = new OracleDataAdapter(command);

                        // create the data set
                        DataSet ds = new DataSet();

                        // fill the data set
                        da.Fill(ds);
                        //string SomeOutVar = command.Parameters["member_cursor"].Value.ToString();


                        List<User> lst = ConvertToUserObject(ds.Tables[0], true);



                        return lst;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}
