using customer.service.dto.Model.Request;
using customer.service.dto.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace customer.service.data.IData
{
    public interface ICustomerData 
    {
       ListCustomer SearchCustomer(SearchCustomerRequest request);
       bool AddCustomer(AddCustomerRequest request);
       Customer GetCustomerByCitizenOrEmail(string citizenId,string email);
       User GetUserByUserId(int userId);
       bool UpdateCustomer(UpdateCustomerRequest request);
       bool DeleteCustomer(DeleteCustomerRequest request);
    }
}
