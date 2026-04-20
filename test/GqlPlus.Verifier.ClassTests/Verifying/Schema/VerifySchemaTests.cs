using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema;

[TracePerTest]
public class VerifySchemaTests
  : VerifierTestsBase
{
  private readonly ForVU<IAstSchemaCategory> _categoryOutputs = new();
  private readonly ForVU<IAstSchemaDirective> _directiveInputs = new();
  private readonly ForVA<IAstSchemaOption> _optionsAliased = new();
  private readonly ForVA<IAstType> _typesAliased = new();
  private readonly ForV<IAstType[]> _types = new();
  private readonly VerifySchema _verifier;

  private readonly IAstSchema _schema;

  public VerifySchemaTests()
  {
    VerifierRepo.UsageFor<IAstSchemaCategory>().Returns(_categoryOutputs.Intf);
    VerifierRepo.UsageFor<IAstSchemaDirective>().Returns(_directiveInputs.Intf);
    VerifierRepo.AliasedFor<IAstSchemaOption>().Returns(_optionsAliased.Intf);
    VerifierRepo.AliasedFor<IAstType>().Returns(_typesAliased.Intf);
    VerifierRepo.VerifierFor<IAstType[]>().Returns(_types.Intf);
    _verifier = new(VerifierRepo);

    _schema = A.Error<IAstSchema>();
  }

  [Fact]
  public void Verify_CallsVerifiersAndCombinesErrors()
  {
    _schema.Errors.Returns("item".MakeMessages());

    Errors.AddRange("error".MakeMessages());

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

  [Fact]
  public void Verify_Schema_WithOutputDeclaration_ReturnsNoErrors()
  {
    IAstObject<IAstOutputField> output = A.Of<IAstObject<IAstOutputField>, IAstType>();
    _schema.Declarations.Returns([output]);

    _verifier.Verify(_schema, Errors);

    Errors.ShouldBeEmpty();
  }
}
