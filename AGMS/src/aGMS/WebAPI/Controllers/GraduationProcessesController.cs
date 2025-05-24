using Application.Features.GraduationProcesses.Commands.Create;
using Application.Features.GraduationProcesses.Commands.Delete;
using Application.Features.GraduationProcesses.Commands.Update;
using Application.Features.GraduationProcesses.Commands.ApproveByAdvisor;
using Application.Features.GraduationProcesses.Commands.ApproveByDepartmentSecretary;
using Application.Features.GraduationProcesses.Commands.ApproveByFacultyDeansOffice;
using Application.Features.GraduationProcesses.Commands.ApproveByStudentAffairs;
using Application.Features.GraduationProcesses.Queries.GetById;
using Application.Features.GraduationProcesses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GraduationProcessesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateGraduationProcessCommand createGraduationProcessCommand)
    {
        CreatedGraduationProcessResponse response = await Mediator.Send(createGraduationProcessCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGraduationProcessCommand updateGraduationProcessCommand)
    {
        UpdatedGraduationProcessResponse response = await Mediator.Send(updateGraduationProcessCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedGraduationProcessResponse response = await Mediator.Send(new DeleteGraduationProcessCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdGraduationProcessResponse response = await Mediator.Send(new GetByIdGraduationProcessQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("by-student/{studentId}")]
    public async Task<IActionResult> GetByStudentId([FromRoute] Guid studentId)
    {
        GetByIdGraduationProcessResponse response = await Mediator.Send(new GetByIdGraduationProcessQuery { StudentId = studentId });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGraduationProcessQuery getListGraduationProcessQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListGraduationProcessListItemDto> response = await Mediator.Send(getListGraduationProcessQuery);
        return Ok(response);
    }

    // Rol-bazlı onay endpoint'leri
    [HttpPost("approve-by-advisor")]
    public async Task<IActionResult> ApproveByAdvisor([FromQuery] ApproveByAdvisorCommand command)
    {
        ApprovedByAdvisorResponse response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("approve-by-department-secretary")]
    public async Task<IActionResult> ApproveByDepartmentSecretary([FromQuery] ApproveByDepartmentSecretaryCommand command)
    {
        ApprovedByDepartmentSecretaryResponse response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("approve-by-faculty-deans-office")]
    public async Task<IActionResult> ApproveByFacultyDeansOffice([FromQuery] ApproveByFacultyDeansOfficeCommand command)
    {
        ApprovedByFacultyDeansOfficeResponse response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("approve-by-student-affairs")]
    public async Task<IActionResult> ApproveByStudentAffairs([FromQuery] ApproveByStudentAffairsCommand command)
    {
        ApprovedByStudentAffairsResponse response = await Mediator.Send(command);
        return Ok(response);
    }
}