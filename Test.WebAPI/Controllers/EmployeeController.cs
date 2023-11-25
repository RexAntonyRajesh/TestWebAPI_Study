using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Threading.Tasks;
using System;
using Test.Service.Response;
using Test.services;

namespace TestAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IUserServices userService;
        private IConfiguration configuration;

        public EmployeeController(IUserServices userService,
            IConfiguration configuration) 
        {
            this.userService = userService;
            this.configuration = configuration;
        }


        #region Get Employee Info
        [HttpGet]
        [Route("employee-info")]
        public async Task<IActionResult> GetEmployee()
        {
            ApiResponse apiResponse = new ApiResponse();

            try
            {
                var userResponse = await userService.GetUsers();

                if (userResponse != null)
                {
                    apiResponse = new ApiResponse
                    {
                        Response = userResponse,
                        ErrorMessage = "",
                        StatusCode = (int)HttpStatusCode.OK,
                        Status = true,
                        Message = "data found"
                    };
                }
                else
                {
                    apiResponse = new ApiResponse
                    {
                        Response = null,
                        ErrorMessage = "",
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Status = false,
                        Message = "data not found"
                    };
                }


            }
            catch (Exception ex)
            {
                apiResponse = new ApiResponse
                {
                    Response = null,
                    ErrorMessage = "",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Status = false,
                    Message = "Error occured while retrieving users"
                };
            }

            return new ObjectResult(apiResponse);
        }
        #endregion
    }
}
