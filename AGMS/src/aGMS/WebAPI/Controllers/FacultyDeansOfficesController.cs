using Application.Features.FacultyDeansOffices.Commands.Create;
using Application.Features.FacultyDeansOffices.Commands.Delete;
using Application.Features.FacultyDeansOffices.Commands.Update;
using Application.Features.FacultyDeansOffices.Queries.GetById;
using Application.Features.FacultyDeansOffices.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacultyDeansOfficesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFacultyDeansOfficeCommand createFacultyDeansOfficeCommand)
    {
        CreatedFacultyDeansOfficeResponse response = await Mediator.Send(createFacultyDeansOfficeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFacultyDeansOfficeCommand updateFacultyDeansOfficeCommand)
    {
        UpdatedFacultyDeansOfficeResponse response = await Mediator.Send(updateFacultyDeansOfficeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedFacultyDeansOfficeResponse response = await Mediator.Send(new DeleteFacultyDeansOfficeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdFacultyDeansOfficeResponse response = await Mediator.Send(new GetByIdFacultyDeansOfficeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFacultyDeansOfficeQuery getListFacultyDeansOfficeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListFacultyDeansOfficeListItemDto> response = await Mediator.Send(getListFacultyDeansOfficeQuery);
        return Ok(response);
    }
}