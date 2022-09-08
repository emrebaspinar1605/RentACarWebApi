using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebApi.DbOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Model;

namespace WebApi.Application.CustomerOperations.TokenOperations
{
  public class RefreshTokenCommand
  {
    public string RefreshToken { get; set; }
    private readonly ICarDbContext _context;
 
    private readonly IConfiguration _configuration;
    public RefreshTokenCommand(ICarDbContext context, IConfiguration configuration)
    {
      _context = context;
      _configuration = configuration;
    }
    public Token Handle()
    {
      var customer = _context.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken );
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
        throw new InvalidOperationException("Geçerli bir refresh token bulunamadı.");
      }
    }
  }
}