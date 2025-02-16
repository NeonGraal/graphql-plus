using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast;
using GqlPlus.Token;
using NSubstitute;

namespace GqlPlus.Verifying.Operation;

[TracePerTest]
public class VerifyOperationTests
{
  [Fact]
  public void Verify_CallsOtherVerifiers()
  {
    IVerifyNamed<IGqlpArg, IGqlpVariable> usages = Substitute.For<IVerifyNamed<IGqlpArg, IGqlpVariable>>();
    IVerifyNamed<IGqlpSpread, IGqlpFragment> spreads = Substitute.For<IVerifyNamed<IGqlpSpread, IGqlpFragment>>();
    VerifyOperation verifier = new(usages, spreads);

    IGqlpOperation item = Substitute.For<IGqlpOperation>();
    ITokenMessages errors = new TokenMessages();

    verifier.Verify(item, errors);

    usages.ReceivedWithAnyArgs().Verify(Arg.Any<UsageNamed<IGqlpArg, IGqlpVariable>>(), errors);
    spreads.ReceivedWithAnyArgs().Verify(Arg.Any<UsageNamed<IGqlpSpread, IGqlpFragment>>(), errors);
  }

  [Fact]
  public void Verify_CombinesErrors()
  {
    IVerifyNamed<IGqlpArg, IGqlpVariable> usages = Substitute.For<IVerifyNamed<IGqlpArg, IGqlpVariable>>();
    IVerifyNamed<IGqlpSpread, IGqlpFragment> spreads = Substitute.For<IVerifyNamed<IGqlpSpread, IGqlpFragment>>();
    VerifyOperation verifier = new(usages, spreads);

    IGqlpOperation item = Substitute.For<IGqlpOperation>();
    item.Errors.Returns(new TokenMessages() { new TokenMessage(AstNulls.At, "item") });

    ITokenMessages errors = new TokenMessages() { new TokenMessage(AstNulls.At, "error") };

    verifier.Verify(item, errors);

    errors.Select(e => e.Message).Should().BeEquivalentTo(["error", "item"]);
  }
}
