using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Application.CustomerOperations;
using WebApi.Application.CustomerOperations.TokenOperations;
using WebApi.DbOperations;
using WebApi.TokenOperations.Model;

namespace WebApi.Controllers
{
  
   
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController :Controller
    {
        private readonly ICarDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
    
    public CustomerController(ICarDbContext context, IMapper mapper,IConfiguration configuration)
    {
      _context = context;
      _mapper = mapper;
      _configuration = configuration;
    }

    [HttpPost]
    public IActionResult AddCustomer([FromBody] CreateCustomerModel model)
    {
        var command =new CreateCustomerCommand(_context,_mapper);
        command.Model = model;

        command.Handle();
        return Ok();
    }
    [HttpPost("connect/token")]
    public IActionResult CreateToken([FromBody] CreateTokenModel model)
    {
        var command = new CreateTokenCommand(_context, _mapper, _configuration);
        command.Model = model;
        var token = command.Handle();
        return Ok (token);
    }
    [HttpGet("refreshToken")]
    public IActionResult RefreshToken([FromQuery] string token)
    {
        var command = new RefreshTokenCommand(_context,_configuration);
        command.RefreshToken = token;
        var result = command.Handle();
        return Ok(result);
    }
  }
}
  
