using Application.Features.Advisors.Commands.Create;
using Application.Features.Advisors.Commands.Delete;
using Application.Features.Advisors.Commands.Update;
using Application.Features.Advisors.Queries.GetById;
using Application.Features.Advisors.Queries.GetList;
using Application.Features.Advisors.Queries.GetAdvisorStudents;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Domain.Enums;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvisorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAdvisorCommand createAdvisorCommand)
    {
        CreatedAdvisorResponse response = await Mediator.Send(createAdvisorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAdvisorCommand updateAdvisorCommand)
    {
        UpdatedAdvisorResponse response = await Mediator.Send(updateAdvisorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedAdvisorResponse response = await Mediator.Send(new DeleteAdvisorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAdvisorResponse response = await Mediator.Send(new GetByIdAdvisorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdvisorQuery getListAdvisorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAdvisorListItemDto> response = await Mediator.Send(getListAdvisorQuery);
        return Ok(response);
    }


    [HttpGet("{advisorId}/students")]
    public async Task<IActionResult> GetAdvisorStudents(
        [FromRoute] Guid advisorId,
        [FromQuery] StudentStatus? studentStatus = null,
        [FromQuery] GraduationStatus? graduationStatus = null)
    {
        GetAdvisorStudentsQuery query = new()
        {
            AdvisorId = advisorId,
            StudentStatusFilter = studentStatus,
            GraduationStatusFilter = graduationStatus
        };
        GetListResponse<GetAdvisorStudentsResponse> response = await Mediator.Send(query);
        return Ok(response);
    }
}