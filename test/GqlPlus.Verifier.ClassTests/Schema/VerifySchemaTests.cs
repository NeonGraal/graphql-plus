using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;
using NSubstitute;

namespace GqlPlus.Schema;

[TracePerTest]
public class VerifySchemaTests
  : VerifierBase
{
  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    ForVU<IGqlpSchemaCategory> categoryOutputs = new();
    ForVU<IGqlpSchemaDirective> directiveInputs = new();
    ForVA<IGqlpSchemaOption> optionsAliased = new();
    ForVA<IGqlpType> typesAliased = new();
    ForV<IGqlpType[]> types = new();

    VerifySchema verifier = new(categoryOutputs.Intf, directiveInputs.Intf, optionsAliased.Intf, typesAliased.Intf, types.Intf);

    IGqlpSchema item = For<IGqlpSchema>();
    item.Errors.Returns(MakeMessages("item"));

    Errors.AddRange(MakeMessages("error"));

    verifier.Verify(item, Errors);

    // using AssertionScope scope = new();

    categoryOutputs.Called();
    directiveInputs.Called();
    optionsAliased.Called();
    typesAliased.Called();
    types.Called();
    Errors.Select(e => e.Message).ShouldBe(["error", "item"]);
  }
}
