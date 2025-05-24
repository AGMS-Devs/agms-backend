using Application.Features.Rectorates.Commands.Create;
using Application.Features.Rectorates.Commands.Delete;
using Application.Features.Rectorates.Commands.Update;
using Application.Features.Rectorates.Queries.GetById;
using Application.Features.Rectorates.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RectoratesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRectorateCommand createRectorateCommand)
    {
        CreatedRectorateResponse response = await Mediator.Send(createRectorateCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRectorateCommand updateRectorateCommand)
    {
        UpdatedRectorateResponse response = await Mediator.Send(updateRectorateCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedRectorateResponse response = await Mediator.Send(new DeleteRectorateCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdRectorateResponse response = await Mediator.Send(new GetByIdRectorateQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRectorateQuery getListRectorateQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRectorateListItemDto> response = await Mediator.Send(getListRectorateQuery);
        return Ok(response);
    }
}