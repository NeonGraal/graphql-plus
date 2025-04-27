using GqlPlus.Abstractions.Schema;
using NSubstitute;

namespace GqlPlus.Verifying.Schema;

[TracePerTest]
public class VerifySchemaTests
  : VerifierBase
{
  private readonly ForVU<IGqlpSchemaCategory> _categoryOutputs = new();
  private readonly ForVU<IGqlpSchemaDirective> _directiveInputs = new();
  private readonly ForVA<IGqlpSchemaOption> _optionsAliased = new();
  private readonly ForVA<IGqlpType> _typesAliased = new();
  private readonly ForV<IGqlpType[]> _types = new();
  private readonly VerifySchema _verifier;

  private readonly IGqlpSchema _schema;

  public VerifySchemaTests()
  {
    _verifier = new(_categoryOutputs.Intf, _directiveInputs.Intf, _optionsAliased.Intf, _typesAliased.Intf, _types.Intf);

    _schema = EFor<IGqlpSchema>();
  }

  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    _schema.Errors.Returns(MakeMessages("item"));

    Errors.AddRange(MakeMessages("error"));

    _verifier.Verify(_schema, Errors);

    _verifier.ShouldSatisfyAllConditions(
      _categoryOutputs.Called,
      _directiveInputs.Called,
      _optionsAliased.Called,
      _typesAliased.Called,
      _types.Called,
      () => Errors.Select(e => e.Message).ShouldBe(["error", "item"]));
  }

  [Fact]
  public void Verify_Schema_WithNoDeclarations_ReturnsNoErrors()
  {
    _verifier.Verify(_schema, Errors);

    Errors.ShouldBeEmpty();
  }
}
