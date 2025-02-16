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
    IVerifyNamed<IGqlpArg, IGqlpVariable> usages = For<IVerifyNamed<IGqlpArg, IGqlpVariable>>();
    IVerifyNamed<IGqlpSpread, IGqlpFragment> spreads = For<IVerifyNamed<IGqlpSpread, IGqlpFragment>>();
    VerifyOperation verifier = new(usages, spreads);

    IGqlpOperation item = For<IGqlpOperation>();
    item.Errors.Returns(MakeMessages("item"));

    ITokenMessages errors = MakeMessages("error");

    verifier.Verify(item, errors);

    using AssertionScope scope = new();

    usages.ReceivedWithAnyArgs().Verify(Arg.Any<UsageNamed<IGqlpArg, IGqlpVariable>>(), errors);
    spreads.ReceivedWithAnyArgs().Verify(Arg.Any<UsageNamed<IGqlpSpread, IGqlpFragment>>(), errors);
    errors.Select(e => e.Message).Should().BeEquivalentTo(["error", "item"]);
  }
}
