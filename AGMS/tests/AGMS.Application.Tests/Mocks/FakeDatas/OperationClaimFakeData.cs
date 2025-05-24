using Domain.Entities;
using NArchitecture.Core.Test.Application.FakeData;
using System;

namespace StarterProject.Application.Tests.Mocks.FakeDatas;

public class OperationClaimFakeData : BaseFakeData<OperationClaim, Guid>
{
    public override List<OperationClaim> CreateFakeData()
    {
        return
        [
            new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Admin" },
            new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Example.Create" },
            new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Example.Delete" },
            new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Example.Update" },
            new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Moderator" },
        ];
    }
}
