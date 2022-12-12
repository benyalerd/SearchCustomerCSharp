using customer.service.data.IData;
using customer.service.dto;
using customer.service.dto.Model.Request;
using customer.service.dto.Model.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace customer.service.data.Data
{
    public class CustomerData : BaseData,ICustomerData
    {
        private const string SP_SEARCH_CUSTOMER = "[SP_SEARCH_CUSTOMER]";
        #region Constructor
        public CustomerData(string connetionString) : base(connetionString)
        {
        }
        #endregion

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
