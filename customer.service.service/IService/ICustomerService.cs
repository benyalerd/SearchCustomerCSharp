using customer.service.dto.Model.Request;
using customer.service.dto.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace customer.service.service.IService
{
    public interface ICustomerService
    {
        ListCustomer SearchCustomer(SearchCustomerRequest request);
        BaseResponse AddCustomer(AddCustomerRequest request);
    }
}
