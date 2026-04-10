using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

[TracePerTest]
public class VerifyOperationTests
  : VerifierTestsBase
{
  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    IVerifyIdentified<IGqlpArg, IAstVariable> usages = A.Of<IVerifyIdentified<IGqlpArg, IAstVariable>>();
    IVerifyIdentified<IGqlpSpread, IAstFragment> spreads = A.Of<IVerifyIdentified<IGqlpSpread, IAstFragment>>();
    VerifierRepo.IdentifiedFor<IGqlpArg, IAstVariable>().Returns(usages);
    VerifierRepo.IdentifiedFor<IGqlpSpread, IAstFragment>().Returns(spreads);
    VerifyOperation verifier = new(VerifierRepo);

    IAstOperation item = A.Of<IAstOperation>();
    item.Errors.Returns("item".MakeMessages());

    Errors.AddRange("error".MakeMessages());

    verifier.Verify(item, Errors);

    verifier.ShouldSatisfyAllConditions(
      () => usages.ReceivedWithAnyArgs().Verify(Arg.Any<UsageIdentified<IGqlpArg, IAstVariable>>(), Errors),
      () => spreads.ReceivedWithAnyArgs().Verify(Arg.Any<UsageIdentified<IGqlpSpread, IAstFragment>>(), Errors),
      () => Errors.Select(e => e.Message).ShouldBe(["error", "item"]));
  }
}
