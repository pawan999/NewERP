using ERPAPI.Entities;
using ERPEntities;
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
    public class ServiceRequestController : ControllerBase
    {
        private readonly IJwtAuth jwtAuth;
        private readonly IServiceRequestService ObjIServiceRequestService;

        private readonly List<Member> lstMember = new List<Member>()
        {
            new Member{Id=1, Name="Kirtesh" },
            new Member {Id=2, Name="Nitya" },
            new Member{Id=3, Name="pankaj"}
        };
        public ServiceRequestController(IJwtAuth jwtAuth, IServiceRequestService serviceRequestService)
        {
            this.jwtAuth = jwtAuth;
            this.ObjIServiceRequestService = serviceRequestService;
        }
      

        [HttpPost("AddServiceRequest")]
        public IActionResult AddServiceRequest([FromBody] ServiceRequest serviceRequest)
        {
            var token = ObjIServiceRequestService.AddServiceRequest(serviceRequest);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [HttpPost("UpdateServiceRequest")]
        public IActionResult UpdateServiceRequest([FromBody] ServiceRequest serviceRequest)
        {
            var token = ObjIServiceRequestService.UpdateServiceRequest(serviceRequest);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        

        [HttpGet("GetAllServiceRequest")]
       [Authorize]
        public IActionResult GetAllServiceRequest()
        {
            User objuser = ClaimsManager.GetCurrentUser(HttpContext);
            var token = ObjIServiceRequestService.GetAllServiceRequest(objuser);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [HttpGet("{id}")]
        // [Authorize]
        public IActionResult ServiceRequestByid(int id)
        {

            

            var token = ObjIServiceRequestService.GetServiceRequestById(id);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
