using Application.Features.MailLogs.Commands.Create;
using Application.Features.MailLogs.Commands.Delete;
using Application.Features.MailLogs.Commands.Update;
using Application.Features.MailLogs.Queries.GetById;
using Application.Features.MailLogs.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MailLogsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMailLogCommand createMailLogCommand)
    {
        CreatedMailLogResponse response = await Mediator.Send(createMailLogCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMailLogCommand updateMailLogCommand)
    {
        UpdatedMailLogResponse response = await Mediator.Send(updateMailLogCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMailLogResponse response = await Mediator.Send(new DeleteMailLogCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMailLogResponse response = await Mediator.Send(new GetByIdMailLogQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMailLogQuery getListMailLogQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMailLogListItemDto> response = await Mediator.Send(getListMailLogQuery);
        return Ok(response);
    }
}