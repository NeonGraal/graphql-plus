using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Modelling.Objects;

public class OutputReferenceModelTests(
  IModeller<OutputReferenceAst, OutputBaseModel> modeller
) : TestReferenceModel<OutputReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void Model_EnumArguments(string name, string[] arguments, string enumValue)
    => ReferenceChecks.Reference_Expected(
      ReferenceChecks.ReferenceAst(name) with { Arguments = [.. arguments.Select(a => ReferenceChecks.ReferenceAst(a) with { EnumValue = enumValue })] },
      ReferenceChecks.ExpectedReference(name, false, _checks.ExpectedEnumArguments(arguments, enumValue))
      );

  internal override ICheckReferenceModel<OutputReferenceAst> ReferenceChecks => _checks;

  private readonly OutputReferenceModelChecks _checks = new(modeller);
}

internal sealed class OutputReferenceModelChecks(
  IModeller<OutputReferenceAst, OutputBaseModel> modeller
) : CheckReferenceModel<OutputReferenceAst, OutputBaseModel>(modeller, TypeKindModel.Output)
{
  internal string[] ExpectedEnumArguments(string[] arguments, string enumValue)
    => [.. ItemsExpected("arguments:", arguments,
      a => ["- !_OutputArgument", "  kind: !_SimpleKind Enum", "  name: " + a, "  value: " + enumValue])];

  protected override OutputReferenceAst NewReferenceAst(string name)
    => new(AstNulls.At, name);
}
