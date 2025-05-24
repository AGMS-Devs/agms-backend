using Application.Features.TakenCourses.Commands.Create;
using Application.Features.TakenCourses.Commands.Delete;
using Application.Features.TakenCourses.Commands.Update;
using Application.Features.TakenCourses.Queries.GetById;
using Application.Features.TakenCourses.Queries.GetList;
using Application.Features.TakenCourses.Queries.GetByStudent;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TakenCoursesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTakenCourseCommand createTakenCourseCommand)
    {
        CreatedTakenCourseResponse response = await Mediator.Send(createTakenCourseCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTakenCourseCommand updateTakenCourseCommand)
    {
        UpdatedTakenCourseResponse response = await Mediator.Send(updateTakenCourseCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedTakenCourseResponse response = await Mediator.Send(new DeleteTakenCourseCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdTakenCourseResponse response = await Mediator.Send(new GetByIdTakenCourseQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTakenCourseQuery getListTakenCourseQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTakenCourseListItemDto> response = await Mediator.Send(getListTakenCourseQuery);
        return Ok(response);
    }

    [HttpGet("get-by-student/{studentId}")]
    public async Task<IActionResult> GetByStudent([FromRoute] Guid studentId)
    {
        GetTakenCoursesByStudentQuery getTakenCoursesByStudentQuery = new() { StudentId = studentId };
        GetTakenCoursesByStudentResponse response = await Mediator.Send(getTakenCoursesByStudentQuery);
        return Ok(response);
    }
}