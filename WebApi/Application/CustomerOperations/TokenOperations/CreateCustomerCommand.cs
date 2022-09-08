using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.CustomerOperations
{
  public class CreateCustomerCommand
  {
    public CreateCustomerModel Model {get; set;}
    private readonly ICarDbContext _context;
    private readonly IMapper _mapper;

    public CreateCustomerCommand(ICarDbContext dbContext, IMapper mapper)
    {
      _context = dbContext;
      _mapper = mapper;
    }
    public void Handle()
    {
      var user = _context.Customers.SingleOrDefault(x=> x.Email == Model.Email);
      if (user is not null)
        throw new InvalidOperationException("Kullanıcı Zaten Mevcut");
      user = _mapper.Map<Customer>(Model);

      _context.Customers.Add(user);
      _context.SaveChanges();
    }
    
  }
  public class CreateCustomerModel
    {
      public string Name {get; set;}
      public string Surname {get; set;}
      public string Email {get; set;}
      public string Password {get; set;}
    }
}