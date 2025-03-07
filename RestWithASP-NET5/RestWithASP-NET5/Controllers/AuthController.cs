﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASP_NET5.Business;
using RestWithASP_NET5.Data.VO;

namespace RestWithASP_NET5.Controllers
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if (user == null)
                return BadRequest("Invalid client request.");

            var token = _loginBusiness.ValidateCredentials(user);
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVO)
        {
            if (tokenVO == null)
                return BadRequest("Invalid client request.");

            var token = _loginBusiness.ValidateCredentials(tokenVO);
            if (token == null)
                return BadRequest("Invalid client request.");

            return Ok(token);
        }

        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var result = _loginBusiness.RevokeToken(User.Identity.Name);

            if (!result)
                return BadRequest("Invalid client request.");

            return NoContent();
        }
    }
}
