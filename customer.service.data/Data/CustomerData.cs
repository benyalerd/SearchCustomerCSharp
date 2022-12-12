using customer.service.data.IData;
using customer.service.dto;
using customer.service.dto.Model.Request;
using customer.service.dto.Model.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace customer.service.data.Data
{
    public class CustomerData : BaseData,ICustomerData
    {
        private const string SP_SEARCH_CUSTOMER = "[SP_SEARCH_CUSTOMER]";
        private const string SP_GET_CUSTOMER_BY_CITIZENID_OR_EMAIL = "[SP_GET_CUSTOMER_BY_CITIZENID_OR_EMAIL]";
        private const string SP_GET_USER_BY_USERID = "[SP_GET_USER_BY_USERID]";
        private const string SP_ADD_CUSTOMER = "[SP_ADD_CUSTOMER]";
        #region Constructor
        public CustomerData(string connetionString) : base(connetionString)
        {
        }
        #endregion

        public bool AddCustomer(AddCustomerRequest request)
        {
            try
            {
                    ExecuteNonQuery(SP_ADD_CUSTOMER,
                    ("custName", ConvertDTA(request.CustName)),
                    ("email", ConvertDTA(request.Email)),
                    ("citizenId", ConvertDTA(request.CitizenId)),
                    ("birthDate", ConvertDTA(request.BirthDate)),
                    ("custLastName", ConvertDTA(request.CitizenId)),
                    ("telephone", ConvertDTA(request.Telephone)),
                    ("userId", ConvertDTA(request.UserId)));
                
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer GetCustomerByCitizenOrEmail(string citizenId, string email)
        {
            Customer customer = new Customer();
            DataNamesMapper<Customer> mapper = new DataNamesMapper<Customer>();
            try
            {
                DataSet dsResults = ExecuteDataSet(SP_GET_CUSTOMER_BY_CITIZENID_OR_EMAIL,
                    ("citizenId", ConvertDTA(citizenId)),
                    ("email", ConvertDTA(email)));
                if ((dsResults != null) && (dsResults.Tables[0].Rows.Count > 0))
                {
                    if (dsResults.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        customer  = mapper.Map(dsResults.Tables[0].Rows[0]);
                    }
                }
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserByUserId(int userId)
        {
            User user = new User();
            DataNamesMapper<User> mapper = new DataNamesMapper<User>();
            try
            {
                DataSet dsResults = ExecuteDataSet(SP_GET_USER_BY_USERID,
                    ("userId", ConvertDTA(userId)));
                if ((dsResults != null) && (dsResults.Tables[0].Rows.Count > 0))
                {
                    if (dsResults.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        user = mapper.Map(dsResults.Tables[0].Rows[0]);
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ListCustomer SearchCustomer(SearchCustomerRequest request)
        {
            ListCustomer listCustomers = new ListCustomer();
            DataNamesMapper<Customer> mapper = new DataNamesMapper<Customer>();
            try
            {
                DataSet dsResults = ExecuteDataSet(SP_SEARCH_CUSTOMER,
                    ("custName", ConvertDTA(request.CustName)),
                    ("email", ConvertDTA(request.Email)),
                    ("citizenId", ConvertDTA(request.CitizenId)),
                    ("page", ConvertDTA(request.Page)),
                    ("limit", ConvertDTA(request.Limit)));
                if ((dsResults != null) && (dsResults.Tables[0].Rows.Count > 0))
                {
                    if (dsResults.Tables[0].Rows[0][0] != System.DBNull.Value)
                    {
                        listCustomers.ListCustomers.AddRange(mapper.Map(dsResults.Tables[0]));
                        listCustomers.TotalRecords = Convert.ToInt32(((dsResults.Tables[1].Rows[0][0] == Convert.DBNull) ? 1 : dsResults.Tables[1].Rows[0][0]));
                    }                    
                }
                return listCustomers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
