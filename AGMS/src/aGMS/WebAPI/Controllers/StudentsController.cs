using Application.Features.Students.Commands.Create;
using Application.Features.Students.Commands.Delete;
using Application.Features.Students.Commands.Update;
using Application.Features.Students.Queries.GetById;
using Application.Features.Students.Queries.GetList;
using Application.Features.Students.Queries.GetStudentsByDepartment;
using Application.Features.Students.Queries.GetStudentsByFaculty;
using Application.Features.Students.Queries.GetAllStudents;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentCommand createStudentCommand)
    {
        CreatedStudentResponse response = await Mediator.Send(createStudentCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStudentCommand updateStudentCommand)
    {
        UpdatedStudentResponse response = await Mediator.Send(updateStudentCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedStudentResponse response = await Mediator.Send(new DeleteStudentCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdStudentQuery getByIdStudentQuery = new() { Id = id };
        GetByIdStudentResponse response = await Mediator.Send(getByIdStudentQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentQuery getListStudentQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStudentListItemDto> response = await Mediator.Send(getListStudentQuery);
        return Ok(response);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllStudents()
    {
        GetAllStudentsQuery query = new();
        List<GetAllStudentsListItemDto> response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("by-department/{departmentId}")]
    public async Task<IActionResult> GetStudentsByDepartment([FromRoute] Guid departmentId, [FromQuery] PageRequest pageRequest)
    {
        GetStudentsByDepartmentQuery query = new() { DepartmentId = departmentId, PageRequest = pageRequest };
        GetListResponse<GetStudentsByDepartmentListItemDto> response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("by-faculty/{facultyId}")]
    public async Task<IActionResult> GetStudentsByFaculty([FromRoute] Guid facultyId, [FromQuery] PageRequest pageRequest)
    {
        GetStudentsByFacultyQuery query = new() { FacultyId = facultyId, PageRequest = pageRequest };
        GetListResponse<GetStudentsByFacultyListItemDto> response = await Mediator.Send(query);
        return Ok(response);
    }
}