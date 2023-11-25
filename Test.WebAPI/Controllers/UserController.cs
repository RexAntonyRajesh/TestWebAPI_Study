using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.WebAPI.Base;

using Microsoft.Extensions.Configuration;
using System.Net;
using System.Threading.Tasks;
using System;
using Test.Service.Response;
using Test.services;

namespace Test.Controllers
{
    
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        private readonly IUserServices userService;
        private IConfiguration configuration;

        public UserController(IUserServices userService,
            IConfiguration configuration) : base(configuration)
        {
            this.userService = userService;
            this.configuration = configuration;
        }

        #region Get User Info
        [HttpGet]
        [Route("user-info")]
        public async Task<IActionResult> Getusers()
        {
            ApiResponse apiResponse = new ApiResponse();

            try
            {
                var userResponse = await userService.GetUsers();

                if(userResponse != null)
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

        #region User By Id
        [HttpGet]
        [Route("user-by-id/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            ApiResponse apiResponse = new ApiResponse();

            try
            {
                var userResponse = await userService.GetUserById(id);

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

        #region User By EmployeeId
        [HttpGet]
        [Route("user-by-id/{id}")]
        public async Task<IActionResult> GetUserEmployeeById(int id)
        {
            ApiResponse apiResponse = new ApiResponse();

            try
            {
                var userResponse = await userService.GetUserById(id);

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
