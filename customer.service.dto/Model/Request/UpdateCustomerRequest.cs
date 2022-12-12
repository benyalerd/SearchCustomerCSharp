using System;
using System.Collections.Generic;
using System.Text;

namespace customer.service.dto.Model.Request
{
    public class UpdateCustomerRequest
    {
        public int UserId { get; set; }
        public string CustName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public DateTime BirthDate { get; set; }
        public int CustId { get; set; }
    }
}
