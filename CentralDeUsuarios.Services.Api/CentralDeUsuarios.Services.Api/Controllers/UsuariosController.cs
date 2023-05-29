﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeUsuarios.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //HttpPost para criar um usuario
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
