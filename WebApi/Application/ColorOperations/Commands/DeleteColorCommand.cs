using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.ColorOperationsCommands.Commands
{
  public class DeleteColorCommand
  {
    public int ColorId;
    private readonly ICarDbContext _context;

    public DeleteColorCommand(ICarDbContext context)
    {
      _context = context;
    }
    public void Handle()
    {
      var color = _context.Colors.SingleOrDefault(c => c.Id == ColorId);
      if (color is null)
      {
        throw new InvalidOperationException("Renk numarası bulunamadı");
      }
      _context.Colors.Remove(color);
    }
  }
}