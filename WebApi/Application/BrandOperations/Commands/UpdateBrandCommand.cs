using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.BrandOperationsCommands.Commands
{
  public class UpdateBrandCommand
  {
    public BrandModel Model;
    public int BrandId;
    private readonly ICarDbContext _context;

    public UpdateBrandCommand(ICarDbContext context)
    {
      _context = context;
    }
    public void Handle()
    {
      var brand = _context.Brands.SingleOrDefault(x => x.Id == BrandId);
      if (brand is null)
      {
        throw new InvalidOperationException("Marka numarası bulunamadı");
      }
      if (_context.Brands.Any(x => x.Name.ToLower() == Model.Name.ToLower()))
      {
        throw new InvalidOperationException("Marka zaten mevcut");
      }
      brand.Name = string.IsNullOrEmpty(Model.Name.Trim())? brand.Name : Model.Name;
      _context.SaveChanges();
    }
  }
}