using System;
using System.Collections.Generic;
using System.Text;

namespace customer.service.dto.Model.Request
{
    public class SearchCustomerRequest
    {
        public string CustName { get; set; }
        public string Email { get; set; }
        public string CitizenId { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
