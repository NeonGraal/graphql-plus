using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

[TracePerTest]
public class VerifyOperationTests
  : VerifierTestsBase
{
  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    IVerifyIdentified<IAstArg, IAstVariable> usages = A.Of<IVerifyIdentified<IAstArg, IAstVariable>>();
    IVerifyIdentified<IAstSpread, IAstFragment> spreads = A.Of<IVerifyIdentified<IAstSpread, IAstFragment>>();
    VerifierRepo.IdentifiedFor<IAstArg, IAstVariable>().Returns(usages);
    VerifierRepo.IdentifiedFor<IAstSpread, IAstFragment>().Returns(spreads);
    VerifyOperation verifier = new(VerifierRepo);

    IAstOperation item = A.Of<IAstOperation>();
    item.Errors.Returns("item".MakeMessages());

    Errors.AddRange("error".MakeMessages());

    verifier.Verify(item, Errors);

    verifier.ShouldSatisfyAllConditions(
      () => usages.ReceivedWithAnyArgs().Verify(Arg.Any<UsageIdentified<IAstArg, IAstVariable>>(), Errors),
      () => spreads.ReceivedWithAnyArgs().Verify(Arg.Any<UsageIdentified<IAstSpread, IAstFragment>>(), Errors),
      () => Errors.Select(e => e.Message).ShouldBe(["error", "item"]));
  }
}
