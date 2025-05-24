using Application.Features.Ceremonies.Commands.Create;
using Application.Features.Ceremonies.Commands.Delete;
using Application.Features.Ceremonies.Commands.Update;
using Application.Features.Ceremonies.Queries.GetById;
using Application.Features.Ceremonies.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CeremoniesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCeremonyCommand createCeremonyCommand)
    {
        CreatedCeremonyResponse response = await Mediator.Send(createCeremonyCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCeremonyCommand updateCeremonyCommand)
    {
        UpdatedCeremonyResponse response = await Mediator.Send(updateCeremonyCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedCeremonyResponse response = await Mediator.Send(new DeleteCeremonyCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCeremonyResponse response = await Mediator.Send(new GetByIdCeremonyQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCeremonyQuery getListCeremonyQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCeremonyListItemDto> response = await Mediator.Send(getListCeremonyQuery);
        return Ok(response);
    }
}