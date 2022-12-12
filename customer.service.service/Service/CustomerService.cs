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

        public BaseResponse AddCustomer(AddCustomerRequest request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                User user = _customerData.GetUserByUserId(request.UserId);
                if (user == null || user.UserId == 0)
                {
                    response.ErrorCode = "002";
                    response.ErrorMessage = "user id is not found";
                    return response;
                }
                Customer customer = _customerData.GetCustomerByCitizenOrEmail(request.CitizenId, request.Email);
                if(customer != null && customer.CustId != 0)
                {
                    response.ErrorCode = "004";
                    response.ErrorMessage = "citizen id or email is duplicate";
                    return response;
                }
                bool isAdd = _customerData.AddCustomer(request);
                if (!isAdd)
                {
                    response.ErrorCode = "005";
                    response.ErrorMessage = "Failed to add or update customer";
                    return response;
                }
                response.IsSuccess = true;
                response.ErrorCode = "000";
                response.ErrorMessage = "Success";
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BaseResponse DeleteCustomer(DeleteCustomerRequest request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                User user = _customerData.GetUserByUserId(request.UserId);
                if (user == null || user.UserId == 0)
                {
                    response.ErrorCode = "002";
                    response.ErrorMessage = "user id is not found";
                    return response;
                }
                bool isAdd = _customerData.DeleteCustomer(request);
                if (!isAdd)
                {
                    response.ErrorCode = "005";
                    response.ErrorMessage = "Failed to add or update customer";
                    return response;
                }
                response.IsSuccess = true;
                response.ErrorCode = "000";
                response.ErrorMessage = "Success";
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                    return listCustomers;
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

        public BaseResponse UpdateCustomer(UpdateCustomerRequest request)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                User user = _customerData.GetUserByUserId(request.UserId);
                if (user == null || user.UserId == 0)
                {
                    response.ErrorCode = "002";
                    response.ErrorMessage = "user id is not found";
                    return response;
                }
                bool isAdd = _customerData.UpdateCustomer(request);
                if (!isAdd)
                {
                    response.ErrorCode = "005";
                    response.ErrorMessage = "Failed to add or update customer";
                    return response;
                }
                response.IsSuccess = true;
                response.ErrorCode = "000";
                response.ErrorMessage = "Success";
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
