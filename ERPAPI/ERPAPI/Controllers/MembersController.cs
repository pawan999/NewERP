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
    public class MembersController : ControllerBase
    {
        private readonly IJwtAuth jwtAuth;
        private readonly IMembersService ObjmembersService;

        private readonly List<Member> lstMember = new List<Member>()
        {
            new Member{Id=1, Name="Kirtesh" },
            new Member {Id=2, Name="Nitya" },
            new Member{Id=3, Name="pankaj"}
        };
        public MembersController(IJwtAuth jwtAuth, IMembersService membersService)
        {
            this.jwtAuth = jwtAuth;
            this.ObjmembersService = membersService;
        }
        // GET: api/<MembersController>
        [HttpGet]
        public IEnumerable<Member> AllMembers()
        {
            
            return lstMember;
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
       // [Authorize]
        public IActionResult MemberByid(long id)
        {

            // User objuser=   ClaimsManager.GetCurrentUser(HttpContext);

            var token = ObjmembersService.GetAllTeammembersById(id);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [AllowAnonymous]
        // POST api/<MembersController>
        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody] UserCredential userCredential)
        {
            var user = jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
            if (user == null)
                return Unauthorized();
            return Ok(user);
        }

        [HttpPost("AddMember")]
        public IActionResult AddMember([FromBody] User user)
        {
            var token = ObjmembersService.AddMember(user);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [HttpPost("UpdateMember")]
        public IActionResult UpdateMember([FromBody] User user)
        {
            var token = ObjmembersService.UpdateMember(user);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [HttpPost("DeleteMember")]
        public IActionResult DeleteMember(long ID)
        {
            var token = ObjmembersService.DeleteMember(ID);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [HttpGet("GetAllTeammembers")]
        public IActionResult GetAllTeammembers()
        {
            var token = ObjmembersService.GetAllTeammembers();
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [HttpGet("GetAllTeammembersByRole")]
        public IActionResult GetAllTeammembersByRole(int RoleId)
        {
            var token = ObjmembersService.GetAllTeammembersByRole(RoleId);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
        [HttpGet("GetAllTeammembersByDepartment")]
        public IActionResult GetAllTeammembersByDepartment(int DepartmentId)
        {
            var token = ObjmembersService.GetAllTeammembersByDepartment(DepartmentId);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
        [HttpGet("GetAllAccountManager")]
        public IActionResult GetAllAccountManager()
        {
            var token = ObjmembersService.GetAllAccountManager();
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }



    }
}
