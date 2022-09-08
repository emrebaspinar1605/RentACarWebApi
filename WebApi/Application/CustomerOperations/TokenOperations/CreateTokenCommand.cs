using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebApi.DbOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Model;

namespace WebApi.Application.CustomerOperations.TokenOperations
{
  public class CreateTokenCommand
  {
    public CreateTokenModel Model { get; set;}
    private readonly ICarDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public CreateTokenCommand(ICarDbContext context, IMapper mapper, IConfiguration configuration)
    {
      _context = context;
      _mapper = mapper;
      _configuration = configuration;
    }
    public Token Handle()
    {
      var customer = _context.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
      if (customer is not null)
      {
        var handler = new TokenHandler(_configuration);
        var token = handler.CreateAccesToken(customer);

        customer.RefreshToken = token.RefreshToken;
        customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(10);
        _context.SaveChanges();
        return token;
      }
      else
      {
        throw new InvalidOperationException("Müşteri maili veya şifresi hatalı");
      }
    }
  }

  public class CreateTokenModel
  {
    public string Email { get; set; }
    public string Password { get; set; }
  }
}