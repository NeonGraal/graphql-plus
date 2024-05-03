using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Modelling.Objects;

public class OutputBaseModelTests(
  IModeller<OutputBaseAst, OutputBaseModel> modeller
) : TestObjBaseModel<OutputBaseAst>
{
  [Theory, RepeatData(Repeats)]
  public void Model_EnumArguments(string name, string[] arguments, string enumValue)
    => ObjBaseChecks.ObjBase_Expected(
      ObjBaseChecks.ObjBaseAst(name) with { Arguments = [.. arguments.Select(a => ObjBaseChecks.ObjBaseAst(a) with { EnumValue = enumValue })] },
      ObjBaseChecks.ExpectedObjBase(name, false, _checks.ExpectedEnumArguments(arguments, enumValue))
      );

  internal override ICheckObjBaseModel<OutputBaseAst> ObjBaseChecks => _checks;

  private readonly OutputBaseModelChecks _checks = new(modeller);
}

internal sealed class OutputBaseModelChecks(
  IModeller<OutputBaseAst, OutputBaseModel> modeller
) : CheckObjBaseModel<OutputBaseAst, OutputBaseModel>(modeller, TypeKindModel.Output)
{
  internal string[] ExpectedEnumArguments(string[] arguments, string enumValue)
    => [.. ItemsExpected("arguments:", arguments,
      a => ["- !_OutputArgument", "  name: " + a, "  typeKind: !_SimpleKind Enum", "  value: " + enumValue])];

  protected override OutputBaseAst NewObjBaseAst(string name)
    => new(AstNulls.At, name);
}
