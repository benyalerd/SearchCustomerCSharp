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
    }
}
