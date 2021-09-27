using ArquitecturaAPI.Responses;
using ArquitecturaAPI.Users.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ArquitecturaAPI.Users.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class GetController : ControllerBase
    {
        private readonly UserRepository _repository;

        public GetController(UserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<UserDTO> ListUsers()
        {
            return Ok(new ApiResponse(_repository.All())); 
        }
    }
}
