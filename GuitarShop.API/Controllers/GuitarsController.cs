using GuitarShop.Application.Features.Guitars.Commands;
using GuitarShop.Application.Features.Guitars.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuitarsController : ControllerBase
{
    private readonly IMediator _mediator;

    public GuitarsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var guitars = await _mediator.Send(new GetGuitarsQuery());
        if (guitars.IsFailure)
            return NotFound(guitars.Error);
        return Ok(guitars);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateGuitarCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var guitar = await _mediator.Send(new GetGuitarByIdQuery(id));
        if(guitar.IsFailure)
            return NotFound(guitar.Error);

        return Ok(guitar);
    }
}