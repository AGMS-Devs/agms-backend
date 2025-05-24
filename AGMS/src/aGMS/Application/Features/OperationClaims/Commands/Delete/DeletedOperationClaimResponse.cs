using NArchitecture.Core.Application.Responses;
using System;

namespace Application.Features.OperationClaims.Commands.Delete;

public class DeletedOperationClaimResponse : IResponse
{
    public Guid Id { get; set; }
}
