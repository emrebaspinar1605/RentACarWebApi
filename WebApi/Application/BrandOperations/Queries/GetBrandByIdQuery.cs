using System;
using System.Linq;
using AutoMapper;
using WebApi.Application.BrandOperationsCommands.Commands;
using WebApi.DbOperations;

namespace WebApi.Application.BrandOperationsCommands.Queries
{
  public class GetBrandByIdQuery
  {
    public int BrandId;
    private readonly ICarDbContext _context;
    private readonly IMapper _mapper;

    public GetBrandByIdQuery(ICarDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public BrandModel Handle()
    {
      var brand = _context.Brands.SingleOrDefault(b => b.Id == BrandId);
      if (brand is null)
      {
        throw new InvalidOperationException("Marka numarası bulunamadı");
      }
      var vm = _mapper.Map<BrandModel>(brand);
      return vm;
    }
  }

  
}