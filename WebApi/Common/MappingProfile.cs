using AutoMapper;
using WebApi.Application.BrandOperationsCommands.Commands;
using WebApi.Application.BrandOperationsCommands.Queries;
using WebApi.Application.CarOperationsCommands.Commands;
using WebApi.Application.CarOperationsCommands.Queries;
using WebApi.Application.ColorOperationsCommands.Commands;
using WebApi.Application.ColorOperationsCommands.Queries;
using WebApi.Application.CustomerOperations;
using WebApi.Entity;

namespace WebApi.Common
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Brand , BrandModel>();
      CreateMap<BrandModel , Brand>();

      CreateMap<Color , ColorModel>();
      CreateMap<ColorModel , Color>();

      CreateMap<Car , CarViewModel>().ForMember(dest => dest.Color , opt => opt.MapFrom(src => src.Color.Name)).ForMember(dest =>dest.Brand , opt => opt.MapFrom(src => src.Brand.Name));
      CreateMap<CarModel , Car>();
      CreateMap<Car, CarModel>();

      CreateMap<CreateCustomerModel,Customer>();
      CreateMap<Customer,CreateCustomerModel>();
    }
  }
}