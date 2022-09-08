using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entity;

namespace WebApi.Application.BrandOperationsCommands.Commands
{
  public class CreateBrandCommand
  {
    public BrandModel Model;
    private readonly ICarDbContext _context;
    private readonly IMapper _mapper;

    public CreateBrandCommand(ICarDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public void Handle()
    {
      var brand = _context.Brands.SingleOrDefault(x => x.Name == Model.Name);
      if (brand is not null)
      {
        throw new InvalidOperationException("Araba markası mevcut.");
      }
        brand = _mapper.Map<Brand>(Model);
      _context.Brands.Add(brand);
      _context.SaveChanges();
    }
  }

  public class BrandModel
  {
    public string Name { get; set; }
  }
}