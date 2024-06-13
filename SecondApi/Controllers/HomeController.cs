﻿using Microsoft.AspNetCore.Mvc;

namespace SecondApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDateTime()
        {
            return Ok(DateTime.Now);
        }
    }
}