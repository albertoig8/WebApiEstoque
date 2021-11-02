using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiEstoque.Models;
using Microsoft.AspNetCore.Authorization;
using WebApiEstoque.Services;
using WebApiEstoque.Repositories;

namespace WebApiEstoque.Controllers
{
    [Route("v1/account")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuario ou senha inválidos" });

            var token = TokenServices.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]

        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]

        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee, manager")]

        public string Employee() => "Lojista";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]

        public string Manager() => "Estoquista";
    }
}
