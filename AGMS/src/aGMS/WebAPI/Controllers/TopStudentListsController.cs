using Application.Features.TopStudentLists.Commands.Create;
using Application.Features.TopStudentLists.Commands.Delete;
using Application.Features.TopStudentLists.Commands.Update;
using Application.Features.TopStudentLists.Commands.ApproveStudentAffairs;
using Application.Features.TopStudentLists.Commands.SendToRectorate;
using Application.Features.TopStudentLists.Commands.ApproveRectorate;
using Application.Features.TopStudentLists.Queries.GetById;
using Application.Features.TopStudentLists.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TopStudentListsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedTopStudentListResponse>> Add([FromQuery] CreateTopStudentListCommand command)
    {
        CreatedTopStudentListResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTopStudentListResponse>> Update([FromBody] UpdateTopStudentListCommand command)
    {
        UpdatedTopStudentListResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTopStudentListResponse>> Delete([FromRoute] Guid id)
    {
        DeleteTopStudentListCommand command = new() { Id = id };

        DeletedTopStudentListResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpPost("approve-student-affairs")]
    public async Task<ActionResult<ApprovedStudentAffairsResponse>> ApproveStudentAffairs([FromBody] ApproveStudentAffairsCommand command)
    {
        ApprovedStudentAffairsResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpPost("send-to-rectorate")]
    public async Task<ActionResult<SentToRectorateResponse>> SendToRectorate([FromBody] SendToRectorateCommand command)
    {
        SentToRectorateResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpPost("approve-rectorate")]
    public async Task<ActionResult<ApprovedRectorateResponse>> ApproveRectorate([FromBody] ApproveRectorateCommand command)
    {
        ApprovedRectorateResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTopStudentListResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdTopStudentListQuery query = new() { Id = id };

        GetByIdTopStudentListResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListTopStudentListListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTopStudentListQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTopStudentListListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}