using GqlPlus.Abstractions.Operation;
using NSubstitute;

namespace GqlPlus.Verifying.Operation;

[TracePerTest]
public class VerifyOperationTests
  : VerifierBase
{
  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    IVerifyIdentified<IGqlpArg, IGqlpVariable> usages = For<IVerifyIdentified<IGqlpArg, IGqlpVariable>>();
    IVerifyIdentified<IGqlpSpread, IGqlpFragment> spreads = For<IVerifyIdentified<IGqlpSpread, IGqlpFragment>>();
    VerifyOperation verifier = new(usages, spreads);

    IGqlpOperation item = For<IGqlpOperation>();
    item.Errors.Returns(MakeMessages("item"));

    Errors.AddRange(MakeMessages("error"));

    verifier.Verify(item, Errors);

    verifier.ShouldSatisfyAllConditions(
      () => usages.ReceivedWithAnyArgs().Verify(Arg.Any<UsageIdentified<IGqlpArg, IGqlpVariable>>(), Errors),
      () => spreads.ReceivedWithAnyArgs().Verify(Arg.Any<UsageIdentified<IGqlpSpread, IGqlpFragment>>(), Errors),
      () => Errors.Select(e => e.Message).ShouldBe(["error", "item"]));
  }
}
