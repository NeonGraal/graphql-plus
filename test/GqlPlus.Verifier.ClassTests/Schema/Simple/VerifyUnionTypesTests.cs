﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Schema;
using GqlPlus.Verifying;
using GqlPlus.Verifying.Schema.Simple;

namespace GqlPlus.Schema.Simple;

[TracePerTest]
public class VerifyUnionTypesTests
  : UsageVerifierBase<IGqlpUnion>
{
  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    ForM<IGqlpUnionItem> mergeMembers = new();
    VerifyUnionTypes verifier = new(Aliased.Intf, mergeMembers.Intf);

    verifier.Verify(UsageAliased, Errors);

    using AssertionScope scope = new();

    Aliased.Called();
    mergeMembers.NotCalled();
    Errors.Should().BeNullOrEmpty();
  }
}
