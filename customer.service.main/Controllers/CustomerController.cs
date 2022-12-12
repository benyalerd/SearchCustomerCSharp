using customer.service.dto.Model.Request;
using customer.service.dto.Model.Response;
using customer.service.service.IService;
using Microsoft.AspNetCore.Mvc;
using System;


namespace customer.service.main.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerservice;
        public CustomerController(ICustomerService customerservice)
        {
            _customerservice = customerservice;
        }
        [HttpPost]
        [Route("SearchCustomer")]
        public IActionResult GetListBotEntity([FromBody] SearchCustomerRequest request)
        {
            
            ListCustomer ListCustomer = new ListCustomer();
            try
            {                               
                ListCustomer = _customerservice.SearchCustomer(request);                
            }
            catch (Exception ex)
            {
                ListCustomer.ErrorMessage = ex.Message;
                ListCustomer.ErrorCode = "003";
                ListCustomer.IsSuccess = false;
            }
            return Ok(ListCustomer);
        }
    }
}
