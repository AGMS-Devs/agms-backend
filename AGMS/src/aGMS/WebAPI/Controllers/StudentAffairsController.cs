using Application.Features.StudentAffairs.Commands.Create;
using Application.Features.StudentAffairs.Commands.Delete;
using Application.Features.StudentAffairs.Commands.Update;
using Application.Features.StudentAffairs.Queries.GetById;
using Application.Features.StudentAffairs.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentAffairsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentAffairsCommand createStudentAffairsCommand)
    {
        CreatedStudentAffairsResponse response = await Mediator.Send(createStudentAffairsCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStudentAffairsCommand updateStudentAffairsCommand)
    {
        UpdatedStudentAffairsResponse response = await Mediator.Send(updateStudentAffairsCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedStudentAffairsResponse response = await Mediator.Send(new DeleteStudentAffairsCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdStudentAffairsResponse response = await Mediator.Send(new GetByIdStudentAffairsQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentAffairsQuery getListStudentAffairsQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStudentAffairsListItemDto> response = await Mediator.Send(getListStudentAffairsQuery);
        return Ok(response);
    }
}