using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class OutputBaseModelTests(
  IModeller<IGqlpOutputBase, OutputBaseModel> modeller,
  IRenderer<OutputBaseModel> rendering
) : TestObjBaseModel<IGqlpOutputBase, OutputBaseAst>
{
  [Theory, RepeatData(Repeats)]
  public void Model_EnumArguments(string name, string[] arguments, string enumMember)
    => ObjBaseChecks.ObjBase_Expected(
      ObjBaseChecks.ObjBaseAst(name) with { BaseArguments = [.. arguments.Select(a => ObjBaseChecks.ObjBaseAst(a) with { EnumMember = enumMember })] },
      ObjBaseChecks.ExpectedObjBase(name, false, _checks.ExpectedEnumArguments(arguments, enumMember))
      );

  internal override ICheckObjBaseModel<IGqlpOutputBase, OutputBaseAst> ObjBaseChecks => _checks;

  private readonly OutputBaseModelChecks _checks = new(modeller, rendering);
}

internal sealed class OutputBaseModelChecks(
  IModeller<IGqlpOutputBase, OutputBaseModel> modeller,
  IRenderer<OutputBaseModel> rendering
) : CheckObjBaseModel<IGqlpOutputBase, OutputBaseAst, OutputBaseModel>(modeller, rendering, TypeKindModel.Output)
{
  internal string[] ExpectedEnumArguments(string[] arguments, string enumMember)
    => [.. ItemsExpected("typeArguments:", arguments,
      a => ["- !_OutputArgument", "  member: " + enumMember, "  name: " + a, "  typeKind: !_SimpleKind Enum"])];

  protected override OutputBaseAst NewObjBaseAst(string name)
    => new(AstNulls.At, name);
}
