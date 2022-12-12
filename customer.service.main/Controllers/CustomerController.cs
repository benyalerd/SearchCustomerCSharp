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
        public IActionResult SearchCustomer([FromBody] SearchCustomerRequest request)
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

        [HttpPost]
        [Route("AddCustomer")]
        public IActionResult AddCustomer([FromBody] AddCustomerRequest request)
        {

            BaseResponse baseResponse = new BaseResponse();
            try
            {
                baseResponse = _customerservice.AddCustomer(request);
            }
            catch (Exception ex)
            {
                baseResponse.ErrorMessage = ex.Message;
                baseResponse.ErrorCode = "003";
                baseResponse.IsSuccess = false;
            }
            return Ok(baseResponse);
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public IActionResult UpdateCustomer([FromBody] UpdateCustomerRequest request)
        {

            BaseResponse baseResponse = new BaseResponse();
            try
            {
                baseResponse = _customerservice.UpdateCustomer(request);
            }
            catch (Exception ex)
            {
                baseResponse.ErrorMessage = ex.Message;
                baseResponse.ErrorCode = "003";
                baseResponse.IsSuccess = false;
            }
            return Ok(baseResponse);
        }

        [HttpPost]
        [Route("DeleteCustomer")]
        public IActionResult DeleteCustomer([FromBody] DeleteCustomerRequest request)
        {

            BaseResponse baseResponse = new BaseResponse();
            try
            {
                baseResponse = _customerservice.DeleteCustomer(request);
            }
            catch (Exception ex)
            {
                baseResponse.ErrorMessage = ex.Message;
                baseResponse.ErrorCode = "003";
                baseResponse.IsSuccess = false;
            }
            return Ok(baseResponse);
        }
    }
}
