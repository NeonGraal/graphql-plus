﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyUnionsAliasedTests
  : AliasedVerifierTestsBase<IGqlpUnion>
{
  internal override GroupedVerifier<IGqlpUnion> NewGroupedVerifier()
    => new VerifyUnionsAliased(Definition, Merger, LoggerFactory);
}
