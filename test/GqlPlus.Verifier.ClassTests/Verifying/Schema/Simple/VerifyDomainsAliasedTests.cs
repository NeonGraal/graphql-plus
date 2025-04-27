﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
using GqlPlus.Verifying.Schema;
namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyDomainsAliasedTests
  : AliasedVerifierBase<IGqlpDomain>
{
  internal override GroupedVerifier<IGqlpDomain> NewGroupedVerifier()
    => new VerifyDomainsAliased(Definition, Merger, Logger);
}
