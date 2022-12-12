using customer.service.data.IData;
using customer.service.dto.Model.Request;
using customer.service.dto.Model.Response;
using customer.service.service.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace customer.service.service.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerData _customerData;
        public CustomerService(ICustomerData customerData)
        {
            _customerData = customerData;
        }
        public ListCustomer SearchCustomer(SearchCustomerRequest request)
        {
            ListCustomer listCustomers = new ListCustomer();
            try
            {
                listCustomers = _customerData.SearchCustomer(request);
                if(listCustomers == null || listCustomers.ListCustomers == null || listCustomers.ListCustomers.Count <= 0)
                {
                    listCustomers.ErrorCode = "002";
                    listCustomers.ErrorMessage = "Not Found Customer Data";
                    
                }
                listCustomers.IsSuccess = true;
                listCustomers.ErrorCode = "000";
                listCustomers.ErrorMessage = "Success";
                return listCustomers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
