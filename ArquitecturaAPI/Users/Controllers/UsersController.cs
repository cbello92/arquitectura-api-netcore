using Arquitectura.Core;
using ArquitecturaAPI.Responses;
using ArquitecturaAPI.Users.Data;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ArquitecturaAPI.Users.Controllers
{   
    public class UsersController : BaseApiController
    {
        private readonly UserRepository _repository;

        public UsersController(UserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<UserModel> ListUsers()
        {
            return Ok(new ApiResponse(_repository.All())); 
        }

        [HttpPost]
        public ActionResult SaveUser([FromBody] UserModel user)
        {
            //ModelState.Remove("name");
            //user.OnCreate();

            UserModelValidator validator = new UserModelValidator();

            ValidationResult results = validator.Validate(user, options => options.IncludeRuleSets("*"));

            if (results.IsValid == false) {
                return  BadRequest(results.Errors);
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(string id, [FromBody] UserModel user)
        {
            UserModelValidator validator = new UserModelValidator();

            ValidationResult results = validator.Validate(user);

            if (results.IsValid == false)
            {
                return BadRequest(results.Errors);
            }

            return Ok(user);
        }
    }
}
