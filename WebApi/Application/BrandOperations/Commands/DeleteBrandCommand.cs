using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.BrandOperationsCommands.Commands
{
  public class DeleteBrandCommand
  {
    public int BrandId;
    private readonly ICarDbContext _context;

    public DeleteBrandCommand(ICarDbContext context)
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
      _context.Brands.Remove(brand);
      _context.SaveChanges();
    }
  }
}