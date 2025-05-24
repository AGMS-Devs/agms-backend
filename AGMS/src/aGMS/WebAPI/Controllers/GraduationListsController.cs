using Application.Features.GraduationLists.Commands.Create;
using Application.Features.GraduationLists.Commands.Delete;
using Application.Features.GraduationLists.Commands.Update;
using Application.Features.GraduationLists.Queries.GetById;
using Application.Features.GraduationLists.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GraduationListsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateGraduationListCommand createGraduationListCommand)
    {
        CreatedGraduationListResponse response = await Mediator.Send(createGraduationListCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGraduationListCommand updateGraduationListCommand)
    {
        UpdatedGraduationListResponse response = await Mediator.Send(updateGraduationListCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedGraduationListResponse response = await Mediator.Send(new DeleteGraduationListCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdGraduationListResponse response = await Mediator.Send(new GetByIdGraduationListQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGraduationListQuery getListGraduationListQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListGraduationListListItemDto> response = await Mediator.Send(getListGraduationListQuery);
        return Ok(response);
    }
}