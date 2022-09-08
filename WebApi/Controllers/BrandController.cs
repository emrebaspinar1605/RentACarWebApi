using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BrandOperationsCommands.Commands;
using WebApi.Application.BrandOperationsCommands.Commands.Validators;
using WebApi.Application.BrandOperationsCommands.Queries;
using WebApi.Application.BrandOperationsCommands.Queries.Validators;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class BrandController :Controller
    {
        private readonly ICarDbContext _context;
        private readonly IMapper _mapper;

    public BrandController(ICarDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddBrand([FromBody] BrandModel model)
    {
        var command =new CreateBrandCommand(_context,_mapper);
        command.Model = model;
        
        var validator = new CreateBrandCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBrand(int id)
    {
        var command =new DeleteBrandCommand(_context);
        command.BrandId = id;
        var validator = new DeleteBrandCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateBrand([FromBody] BrandModel model,int id)
    {
        var command =new UpdateBrandCommand(_context);
        command.Model = model;
        command.BrandId = id;
        
        var validator = new UpdateBrandCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();
        return Ok();
    }
    [HttpGet]
    public IActionResult GetAllBrand( )
    {
        var query =new GetAllBrandQuery(_context,_mapper);
        var result = query.Handle();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetBrandById(int id)
    {
        var query =new GetBrandByIdQuery(_context,_mapper);
        query.BrandId = id;
        
        var validator = new GetBrandByIdQueryValidator();
        validator.ValidateAndThrow(query);
        var result = query.Handle();
        return Ok(result);
    }
  }
}