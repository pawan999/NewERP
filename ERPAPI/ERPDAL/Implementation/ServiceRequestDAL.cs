

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
    public class ServiceRequestDAL : IServiceRequestDAL
    {

      


        public List<ServiceRequest> ConvertToServiceRequestObj(DataTable dt)
        {
            List<ServiceRequest> lstServiceRequest = new List<ServiceRequest>();

            foreach (DataRow dr in dt.Rows)
            {
                ServiceRequest serviceRequest = new ServiceRequest();
                serviceRequest.TransactionId = Convert.ToInt32(dr["TRANSACTIONID"]);
                serviceRequest.MemberId = Convert.ToInt32(dr["MEMBERID"]);
                serviceRequest.OnBehalfOf = Convert.ToInt32(dr["ONBEHALFOF"]);

                serviceRequest.DepartmentId = Convert.ToInt32(dr["DEPARTMENTID"]);
                serviceRequest.ServiceRequestId = Convert.ToInt32(dr["SERVICEREQUESTID"]);

                serviceRequest.ServiceRequestName = Convert.ToString(dr["SERVICEREQUESTNAME"]);
                serviceRequest.ServiceDescriptionName = Convert.ToString(dr["SERVICEREQUESTDESCRIPTION"]);
                // user.pass = dr["PASSWORD"];
                serviceRequest.AssignedTo = Convert.ToInt32(dr["ASSIGNEDTO"]);

                serviceRequest.IsApprovalNeeded = Convert.ToBoolean(Convert.ToInt16(dr["ISAPPROVALNEEDED"]));
                if(dr["APPROVER"] !=DBNull.Value)
                serviceRequest.Approver = Convert.ToInt32(dr["APPROVER"]);
                serviceRequest.DateCreated = Convert.ToDateTime(dr["DATECREATED"]);
                serviceRequest.Status = Convert.ToInt32(dr["STATUS"]);
                serviceRequest.DateModified = Convert.ToDateTime(dr["DATEMODIFIED"]);
                serviceRequest.LastModifiedBy= Convert.ToInt32(dr["LASTMODIFIEDBY"]);
                serviceRequest.IsDeleted = Convert.ToBoolean(Convert.ToInt16(dr["ISDELETED"]));

                serviceRequest.DepartmentName = Convert.ToString(dr["DEPARTMENTNAME"]);

                serviceRequest.StatusName = Convert.ToString(dr["STATUSNAME"]);
                // user.DateModified = Convert.ToDateTime( dr["DATEMODIFIED"]);


                lstServiceRequest.Add(serviceRequest);

            }

            return lstServiceRequest;
        }

        public bool AddServiceRequest(ServiceRequest serviceRequest)
        {
            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("SP_ERP_Ins_RequestTran", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("p_MEMBERID", OracleDbType.Int32).Value = serviceRequest.MemberId;
                        command.Parameters.Add("p_ONBEHALFOF", OracleDbType.Int32).Value = serviceRequest.OnBehalfOf;
                        command.Parameters.Add("p_DEPARTMENTID", OracleDbType.Int32).Value = serviceRequest.DepartmentId;
                        command.Parameters.Add("p_SERVICEREQUESTID", OracleDbType.Int32).Value = serviceRequest.ServiceRequestId;

                        command.Parameters.Add("p_SERVICEREQUESTNAME", OracleDbType.Varchar2).Value = serviceRequest.ServiceRequestName;
                        command.Parameters.Add("p_SERVICEREQUESTDESCRIPTION", OracleDbType.Varchar2).Value = serviceRequest.ServiceDescriptionName;
                        command.Parameters.Add("p_ASSIGNEDTO", OracleDbType.Int32).Value = serviceRequest.AssignedTo;
                        command.Parameters.Add("p_ISAPPROVALNEEDED", OracleDbType.Char).Value = (serviceRequest.IsApprovalNeeded) ? "1" : "0";
                        command.Parameters.Add("p_APPROVER", OracleDbType.Int32).Value = serviceRequest.Approver;
                        command.Parameters.Add("p_STATUS", OracleDbType.Char).Value = Convert.ToChar(serviceRequest.Status);
                        command.Parameters.Add("p_LASTMODIFIEDBY", OracleDbType.Int32).Value = serviceRequest.LastModifiedBy;


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

        public bool UpdateServiceRequest(ServiceRequest serviceRequest)
        {
            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("SP_ERP_upd_RequestTran", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("p_transactionid", OracleDbType.Int32).Value = serviceRequest.TransactionId;
                        command.Parameters.Add("p_MEMBERID", OracleDbType.Int32).Value = serviceRequest.MemberId;
                        command.Parameters.Add("p_ONBEHALFOF", OracleDbType.Int32).Value = serviceRequest.OnBehalfOf;
                        command.Parameters.Add("p_DEPARTMENTID", OracleDbType.Int32).Value = serviceRequest.DepartmentId;
                        command.Parameters.Add("p_SERVICEREQUESTID", OracleDbType.Int32).Value = serviceRequest.ServiceRequestId;

                        command.Parameters.Add("p_SERVICEREQUESTNAME", OracleDbType.Varchar2).Value = serviceRequest.ServiceRequestName;
                        command.Parameters.Add("p_SERVICEREQUESTDESCRIPTION", OracleDbType.Varchar2).Value = serviceRequest.ServiceDescriptionName;
                        command.Parameters.Add("p_ASSIGNEDTO", OracleDbType.Int32).Value = serviceRequest.AssignedTo;
                        command.Parameters.Add("p_ISAPPROVALNEEDED", OracleDbType.Char).Value = (serviceRequest.IsApprovalNeeded) ? "1" : "0";
                        command.Parameters.Add("p_APPROVER", OracleDbType.Int32).Value = serviceRequest.Approver;
                        command.Parameters.Add("p_STATUS", OracleDbType.Char).Value = Convert.ToChar(serviceRequest.Status);
                        command.Parameters.Add("p_LASTMODIFIEDBY", OracleDbType.Int32).Value = serviceRequest.LastModifiedBy;


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

       

        public List<ServiceRequest> GetAllServiceRequest(User objuser)
        {

           
            

            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("USP_ERP_GetTransactions", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("p_user", OracleDbType.Int32).Value = objuser.Id;
                        string rolename = objuser.RoleName == null ? "" : objuser.RoleName.ToLower();
                        command.Parameters.Add("p_isadmin", OracleDbType.Char).Value = rolename;

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


                        List<ServiceRequest> lst = ConvertToServiceRequestObj(ds.Tables[0]);



                        return lst;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ServiceRequest> GetServiceRequestById(int transactionId)
        {


            string dbuser = "CLSUPPORT";
            string dbpassword = "CLSUPPORT";


            string db = "10.116.60.171/SOS";

            string ConnectionString = "User Id=" + dbuser + ";Password=" + dbpassword + ";Data Source=" + db + ";";
            try
            {
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand("USP_ERP_GetTransactionsById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("p_transactionId", OracleDbType.Int32).Value = transactionId;
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


                        List<ServiceRequest> lst = ConvertToServiceRequestObj(ds.Tables[0]);



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
