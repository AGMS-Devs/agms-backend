using Application.Features.RequiredCourseListCourses.Commands.Create;
using Application.Features.RequiredCourseListCourses.Commands.Delete;
using Application.Features.RequiredCourseListCourses.Commands.Update;
using Application.Features.RequiredCourseListCourses.Queries.GetById;
using Application.Features.RequiredCourseListCourses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequiredCourseListCoursesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedRequiredCourseListCourseResponse>> Add([FromBody] CreateRequiredCourseListCourseCommand command)
    {
        CreatedRequiredCourseListCourseResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedRequiredCourseListCourseResponse>> Update([FromBody] UpdateRequiredCourseListCourseCommand command)
    {
        UpdatedRequiredCourseListCourseResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedRequiredCourseListCourseResponse>> Delete([FromRoute] Guid id)
    {
        DeleteRequiredCourseListCourseCommand command = new() { Id = id };

        DeletedRequiredCourseListCourseResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdRequiredCourseListCourseResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdRequiredCourseListCourseQuery query = new() { Id = id };

        GetByIdRequiredCourseListCourseResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListRequiredCourseListCourseListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRequiredCourseListCourseQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListRequiredCourseListCourseListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}