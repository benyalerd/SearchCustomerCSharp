using System;
using System.Collections.Generic;
using System.Text;

namespace customer.service.dto.Model.Request
{
    public class DeleteCustomerRequest
    {
        public int UserId { get; set; }
        public int CustId { get; set; }
    }
}
