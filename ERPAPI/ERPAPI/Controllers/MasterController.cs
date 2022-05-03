using ERPAPI.Entities;
using ERPServices.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IJwtAuth jwtAuth;
        private readonly IMasterService ObjmasterService;

       
        public MasterController(IJwtAuth jwtAuth, IMasterService masterService)
        {
            this.jwtAuth = jwtAuth;
            this.ObjmasterService = masterService;
        }
      
    

      

        [HttpGet("GetAllDepartments")]
        public IActionResult GetAllDepartments()
        {
            var token = ObjmasterService.GetAllDepartments();
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [HttpGet("GetAllSttaus")]
        public IActionResult GetAllSttaus()
        {
            var token = ObjmasterService.GetAllSttaus();
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }


        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var token = ObjmasterService.GetAllRoles();
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [HttpGet("GetServiceRequestTypes")]
        public IActionResult GetServiceRequestTypes()
        {
            var token = ObjmasterService.GetServiceRequestTypes();
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }


    }
}
