using Application.Features.Messages.Commands.Create;
using Application.Features.Messages.Commands.Delete;
using Application.Features.Messages.Commands.Update;
using Application.Features.Messages.Queries.GetById;
using Application.Features.Messages.Queries.GetList;
using Application.Features.Messages.Queries.GetStudentMessages;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMessageCommand createMessageCommand)
    {
        CreatedMessageResponse response = await Mediator.Send(createMessageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMessageCommand updateMessageCommand)
    {
        UpdatedMessageResponse response = await Mediator.Send(updateMessageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMessageResponse response = await Mediator.Send(new DeleteMessageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMessageResponse response = await Mediator.Send(new GetByIdMessageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromQuery] string? studentNumber)
    {
        GetListMessageQuery getListMessageQuery = new() { PageRequest = pageRequest, StudentNumber = studentNumber };
        GetListResponse<GetListMessageListItemDto> response = await Mediator.Send(getListMessageQuery);
        return Ok(response);
    }

    [HttpGet("student/{studentNumber}")]
    public async Task<IActionResult> GetStudentMessages([FromRoute] string studentNumber, [FromQuery] PageRequest pageRequest)
    {
        GetStudentMessagesQuery getStudentMessagesQuery = new() { StudentNumber = studentNumber, PageRequest = pageRequest };
        GetListResponse<GetStudentMessagesListItemDto> response = await Mediator.Send(getStudentMessagesQuery);
        return Ok(response);
    }
}