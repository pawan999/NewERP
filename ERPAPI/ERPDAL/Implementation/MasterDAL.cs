

using ERPAPI.Entities;
using ERPDAL.Interface;
using ERPEntities;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace ERPDAL.Implementation
{
    public class MasterDAL : IMasterDAL
    {

     


        public List<Department> ConvertToDepartmentObject(DataTable dt)
        {
            List<Department> lstDepartment = new List<Department>();

            foreach (DataRow dr in dt.Rows)
            {
                Department department = new Department();
              
                department.DepartmentName = Convert.ToString(dr["DEPARTMENTNAME"]);

                department.DepartmentId = Convert.ToInt32(dr["DEPARTMENTID"]);

                department.DepartmentAccessType = Convert.ToString(dr["DEPARTMENTACCESSTYPE"]);

                lstDepartment.Add(department);

            }

            return lstDepartment;
        }

        public List<Status> ConvertToStatusObject(DataTable dt)
        {
            List<Status> lstStatus = new List<Status>();

            foreach (DataRow dr in dt.Rows)
            {
                Status status = new Status();

                status.Name = Convert.ToString(dr["NAME"]);

                status.StatusId = Convert.ToInt32(dr["STATUSID"]);

                status.Description = Convert.ToString(dr["DESCRIPTION"]);

                lstStatus.Add(status);

            }

            return lstStatus;
        }

        public List<Role> ConvertToRoleObject(DataTable dt)
        {
            List<Role> lstRole = new List<Role>();

            foreach (DataRow dr in dt.Rows)
            {
                Role role = new Role();

                role.RoleName = Convert.ToString(dr["ROLENAME"]);

                role.RoleId = Convert.ToInt32(dr["ROLEID"]);

               

                lstRole.Add(role);

            }

            return lstRole;
        }



        public List<ServiceRequestType> ConvertToServiceTypeObject(DataTable dt)
        {
            List<ServiceRequestType> lstServiceRequestType = new List<ServiceRequestType>();

            foreach (DataRow dr in dt.Rows)
            {
                ServiceRequestType serviceRequestType = new ServiceRequestType();

                serviceRequestType.ServiceRequestTypeId = Convert.ToInt32(dr["SERVICEREQUESTID"]);

                serviceRequestType.ServiceRequestTypeName = Convert.ToString(dr["SERVICEREQUESTNAME"]);



                lstServiceRequestType.Add(serviceRequestType);

            }

            return lstServiceRequestType;
        }
        public List<Department> GetAllDepartments()
        {


            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("USP_ERP_GETALLDEPARTMENTS", connection))
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


                        List<Department> lst = ConvertToDepartmentObject(ds.Tables[0]);



                        return lst;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<Status> GetAllSttaus()
        {


            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("USP_ERP_GETALLSTATUS", connection))
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


                        List<Status> lst = ConvertToStatusObject(ds.Tables[0]);



                        return lst;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<Role> GetAllRoles()
        {


            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("USP_ERP_GETALLROLES", connection))
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


                        List<Role> lst = ConvertToRoleObject(ds.Tables[0]);



                        return lst;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public List<ServiceRequestType> GetServiceRequestTypes()
        {


            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("USP_ERP_GETSERVICEREQUESTTYPES", connection))
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


                        List<ServiceRequestType> lst = ConvertToServiceTypeObject(ds.Tables[0]);



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
