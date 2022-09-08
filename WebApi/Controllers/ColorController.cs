using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ColorOperationsCommands.Commands;
using WebApi.Application.ColorOperationsCommands.Commands.Validator;
using WebApi.Application.ColorOperationsCommands.Queries;
using WebApi.Application.ColorOperationsCommands.Queries.Validators;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class ColorController :Controller
    {
        private readonly ICarDbContext _context;
        private readonly IMapper _mapper;

    public ColorController(ICarDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddColor([FromBody] ColorModel model)
    {
        var command =new CreateColorCommand(_context,_mapper);
        command.Model = model;
        
        var validator = new CreateColorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteColor(int id)
    {
        var command =new DeleteColorCommand(_context);
        command.ColorId = id;
        var validator = new DeleteColorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateColor([FromBody] ColorModel model,int id)
    {
        var command =new UpdateColorCommand(_context);
        command.Model = model;
        command.ColorId = id;
        
        var validator = new UpdateColorCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
    [HttpGet]
    public IActionResult GetAllColor( )
    {
        var query =new GetAllColorQuery(_context,_mapper);
        var result = query.Handle();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetColorById(int id)
    {
        var query =new GetColorByIdQuery(_context,_mapper);
        query.ColorId = id;
        
        var validator = new GetColorByIdQueryValidator();
        validator.ValidateAndThrow(query);
        var result = query.Handle();
        return Ok(result);
    }
    }
}