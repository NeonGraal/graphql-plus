using GqlPlus.Abstractions.Operation;
using GqlPlus.Verifying.Operation;
using NSubstitute;

namespace GqlPlus.Operation;

[TracePerTest]
public class VerifyOperationTests
  : VerifierBase
{
  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    IVerifyNamed<IGqlpArg, IGqlpVariable> usages = For<IVerifyNamed<IGqlpArg, IGqlpVariable>>();
    IVerifyNamed<IGqlpSpread, IGqlpFragment> spreads = For<IVerifyNamed<IGqlpSpread, IGqlpFragment>>();
    VerifyOperation verifier = new(usages, spreads);

    IGqlpOperation item = For<IGqlpOperation>();
    item.Errors.Returns(MakeMessages("item"));

    Errors.AddRange(MakeMessages("error"));

    verifier.Verify(item, Errors);

    verifier.ShouldSatisfyAllConditions(
      () => usages.ReceivedWithAnyArgs().Verify(Arg.Any<UsageNamed<IGqlpArg, IGqlpVariable>>(), Errors),
      () => spreads.ReceivedWithAnyArgs().Verify(Arg.Any<UsageNamed<IGqlpSpread, IGqlpFragment>>(), Errors),
      () => Errors.Select(e => e.Message).ShouldBe(["error", "item"]));
  }
}
