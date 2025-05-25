using Application.Features.Transcripts.Commands.Create;
using Application.Features.Transcripts.Commands.Delete;
using Application.Features.Transcripts.Commands.Update;
using Application.Features.Transcripts.Commands.UpdateTranscriptCalculations;
using Application.Features.Transcripts.Commands.UpdateAllTranscriptCalculations;
using Application.Features.Transcripts.Queries.GetById;
using Application.Features.Transcripts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TranscriptsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTranscriptCommand createTranscriptCommand)
    {
        CreatedTranscriptResponse response = await Mediator.Send(createTranscriptCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTranscriptCommand updateTranscriptCommand)
    {
        UpdatedTranscriptResponse response = await Mediator.Send(updateTranscriptCommand);

        return Ok(response);
    }

    [HttpPut("calculate/{studentId}")]
    public async Task<IActionResult> UpdateCalculations([FromRoute] Guid studentId)
    {
        UpdatedTranscriptCalculationsResponse response = await Mediator.Send(new UpdateTranscriptCalculationsCommand { StudentId = studentId });

        return Ok(response);
    }

    [HttpPut("calculate-all")]
    public async Task<IActionResult> UpdateAllCalculations()
    {
        UpdatedAllTranscriptCalculationsResponse response = await Mediator.Send(new UpdateAllTranscriptCalculationsCommand());

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedTranscriptResponse response = await Mediator.Send(new DeleteTranscriptCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdTranscriptResponse response = await Mediator.Send(new GetByIdTranscriptQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTranscriptQuery getListTranscriptQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTranscriptListItemDto> response = await Mediator.Send(getListTranscriptQuery);
        return Ok(response);
    }
}