using Application.Features.RequiredCourseLists.Commands.Create;
using Application.Features.RequiredCourseLists.Commands.Delete;
using Application.Features.RequiredCourseLists.Commands.Update;
using Application.Features.RequiredCourseLists.Queries.GetById;
using Application.Features.RequiredCourseLists.Queries.GetList;
using Application.Features.RequiredCourseLists.Queries.GetUncompletedCourses;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.RequiredCourseLists.Queries.GetByStudent;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequiredCourseListsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedRequiredCourseListResponse>> Add([FromBody] CreateRequiredCourseListCommand command)
    {
        CreatedRequiredCourseListResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedRequiredCourseListResponse>> Update([FromBody] UpdateRequiredCourseListCommand command)
    {
        UpdatedRequiredCourseListResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedRequiredCourseListResponse>> Delete([FromRoute] Guid id)
    {
        DeleteRequiredCourseListCommand command = new() { Id = id };

        DeletedRequiredCourseListResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdRequiredCourseListResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdRequiredCourseListQuery query = new() { Id = id };

        GetByIdRequiredCourseListResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListRequiredCourseListListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRequiredCourseListQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListRequiredCourseListListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("get-uncompleted-courses/{studentId}")]
    public async Task<IActionResult> GetUncompletedCourses([FromRoute] Guid studentId)
    {
        GetUncompletedCoursesQuery getUncompletedCoursesQuery = new() { StudentId = studentId };
        GetUncompletedCoursesResponse response = await Mediator.Send(getUncompletedCoursesQuery);
        return Ok(response);
    }

        [HttpGet("get-by-student/{studentId}")]
    public async Task<IActionResult> GetByStudent([FromRoute] Guid studentId)
    {
        GetRequiredCourseListByStudentQuery getRequiredCourseListByStudentQuery = new() { StudentId = studentId };
        GetRequiredCourseListByStudentResponse response = await Mediator.Send(getRequiredCourseListByStudentQuery);
        return Ok(response);
    }
}