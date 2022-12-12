using System;
using System.Collections.Generic;
using System.Text;

namespace customer.service.dto.Model.Response
{
    public class Customer
    {
        [DataNames("customer_id")]
        public int CustId { get; set; }
        [DataNames("citizen_id")]
        public string CitizenId { get; set; }
        [DataNames("birth_date")]
        public DateTime BirthDate { get; set; }
        [DataNames("customer_name")]
        public string CustName { get; set; }
        [DataNames("customer_lastname")]
        public string CustLastName { get; set; }
        [DataNames("email")]
        public string Email { get; set; }
        [DataNames("telephone")]
        public string Telephone { get; set; }

    }

    public class ListCustomer : BaseResponse
    {
        public List<Customer> ListCustomers { get; set; } = new List<Customer>();
        public int TotalRecords { get; set; }
    }

    
}
