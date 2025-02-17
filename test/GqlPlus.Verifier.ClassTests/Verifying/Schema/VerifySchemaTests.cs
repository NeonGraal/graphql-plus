using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
using NSubstitute;

namespace GqlPlus.Verifying.Schema;

[TracePerTest]
public class VerifySchemaTests
  : VerifierBase
{
  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    IVerifyUsage<IGqlpSchemaCategory> categoryOutputs = For<IVerifyUsage<IGqlpSchemaCategory>>();
    IVerifyUsage<IGqlpSchemaDirective> directiveInputs = For<IVerifyUsage<IGqlpSchemaDirective>>();
    IVerifyAliased<IGqlpSchemaOption> optionsAliased = For<IVerifyAliased<IGqlpSchemaOption>>();
    IVerifyAliased<IGqlpType> typesAliased = For<IVerifyAliased<IGqlpType>>();
    IVerify<IGqlpType[]> types = VFor<IGqlpType[]>();

    VerifySchema verifier = new(categoryOutputs, directiveInputs, optionsAliased, typesAliased, types);

    IGqlpSchema item = For<IGqlpSchema>();
    item.Errors.Returns(MakeMessages("item"));

    Errors.AddRange(MakeMessages("error"));

    verifier.Verify(item, Errors);

    using AssertionScope scope = new();

    categoryOutputs.ReceivedWithAnyArgs().Verify(Arg.Any<UsageAliased<IGqlpSchemaCategory>>(), Errors);
    directiveInputs.ReceivedWithAnyArgs().Verify(Arg.Any<UsageAliased<IGqlpSchemaDirective>>(), Errors);
    optionsAliased.ReceivedWithAnyArgs().Verify(Arg.Any<IGqlpSchemaOption[]>(), Errors);
    typesAliased.ReceivedWithAnyArgs().Verify(Arg.Any<IGqlpType[]>(), Errors);
    types.ReceivedWithAnyArgs().Verify(Arg.Any<IGqlpType[]>(), Errors);
    Errors.Select(e => e.Message).Should().BeEquivalentTo(["error", "item"]);
  }
}
