using System;
using System.Collections.Generic;
using System.Text;

namespace customer.service.dto.Model.Response
{
    public class BaseResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
}
