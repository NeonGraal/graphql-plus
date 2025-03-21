﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema.Globals;

namespace GqlPlus.Schema.Globals;

[TracePerTest]
public class VerifyDirectiveInputTests
  : UsageVerifierBase<IGqlpSchemaDirective>
{
  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    VerifyDirectiveInput verifier = new(Aliased.Intf);

    verifier.Verify(UsageAliased, Errors);

    verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      () => Errors.ShouldBeEmpty());
  }
}
