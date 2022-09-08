using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CarOperationsCommands.Commands;
using WebApi.Application.CarOperationsCommands.Commands.Validators;
using WebApi.Application.CarOperationsCommands.Queries;
using WebApi.Application.CarOperationsCommands.Queries.Validators;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]s")]
  public partial class CarController :Controller
  {
        private readonly ICarDbContext _context;
        private readonly IMapper _mapper;

    public CarController(ICarDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddCar([FromBody] CarModel model)
    {
        var command =new CreateCarCommand(_context,_mapper);
        command.Model = model;
        
        var validator = new CreateCarCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteCar(int id)
    {
        var command =new DeleteCarCommand(_context);
        command.CarId = id;
        var validator = new DeleteCarCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateCar([FromBody] CarModel model,int id)
    {
        var command =new UpdateCarCommand(_context);
        command.Model = model;
        command.CarId = id;
        
        var validator = new UpdateCarCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
    [HttpGet]
    public IActionResult GetAllCar( )
    {
        var query =new GetAllCarQuery(_context,_mapper);
        var result = query.Handle();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetCarById(int id)
    {
        var query =new GetCarByIdQuery(_context,_mapper);
        query.CarId = id;
        
        var validator = new GetCarByIdQueryValidator();
        validator.ValidateAndThrow(query);
        var result = query.Handle();
        return Ok(result);
    }
  }
}