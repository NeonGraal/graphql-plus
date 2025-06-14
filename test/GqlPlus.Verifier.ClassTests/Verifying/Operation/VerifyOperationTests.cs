using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

[TracePerTest]
public class VerifyOperationTests
  : VerifierTestsBase
{
  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    IVerifyIdentified<IGqlpArg, IGqlpVariable> usages = A.Of<IVerifyIdentified<IGqlpArg, IGqlpVariable>>();
    IVerifyIdentified<IGqlpSpread, IGqlpFragment> spreads = A.Of<IVerifyIdentified<IGqlpSpread, IGqlpFragment>>();
    VerifyOperation verifier = new(usages, spreads);

    IGqlpOperation item = A.Of<IGqlpOperation>();
    item.Errors.Returns("item".MakeMessages());

    Errors.AddRange("error".MakeMessages());

    verifier.Verify(item, Errors);

    verifier.ShouldSatisfyAllConditions(
      () => usages.ReceivedWithAnyArgs().Verify(Arg.Any<UsageIdentified<IGqlpArg, IGqlpVariable>>(), Errors),
      () => spreads.ReceivedWithAnyArgs().Verify(Arg.Any<UsageIdentified<IGqlpSpread, IGqlpFragment>>(), Errors),
      () => Errors.Select(e => e.Message).ShouldBe(["error", "item"]));
  }
}
