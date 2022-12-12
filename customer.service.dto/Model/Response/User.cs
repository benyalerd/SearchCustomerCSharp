using System;
using System.Collections.Generic;
using System.Text;

namespace customer.service.dto.Model.Response
{
    public class User
    {
        [DataNames("user_id")]
        public int UserId { get; set; }
        [DataNames("email")]
        public string Email { get; set; }
    }
}
