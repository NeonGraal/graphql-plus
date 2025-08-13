using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Schema.Objects;

public class OutputBaseModelTests(
  IOutputBaseModelChecks checks
) : TestObjBaseModel<IGqlpOutputBase, IGqlpOutputArg, OutputBaseModel>(checks)
{
  [Theory, RepeatData]
  public void Model_EnumArgs(string name, string[] arguments, string enumLabel)
    => checks.ObjBase_Expected(
      checks.ObjBaseAst(name, false, [.. arguments.Select(a => checks.EnumObjArg(a, enumLabel))]),
      checks.ExpectedObjBase(name, false, checks.ExpectedEnumArgs(arguments, enumLabel))
      );
}

internal sealed class OutputBaseModelChecks(
  IModeller<IGqlpOutputBase, OutputBaseModel> modeller,
  IEncoder<OutputBaseModel> encoding
) : CheckObjBaseModel<IGqlpOutputBase, IGqlpOutputArg, OutputBaseAst, OutputArgAst, OutputBaseModel>(modeller, encoding, TypeKindModel.Output)
  , IOutputBaseModelChecks
{
  public string[] ExpectedEnumArgs(string[] arguments, string enumLabel)
    => [.. ItemsExpected("typeArgs:", arguments,
      a => ["  - !_TypeRef(_SimpleKind)", "    label: " + enumLabel, "    name: " + a, "    typeKind: !_SimpleKind Enum"])];

  protected override OutputBaseAst NewObjBaseAst(string input, bool isTypeParam, IGqlpOutputArg[] args)
    => new(AstNulls.At, input) {
      IsTypeParam = isTypeParam,
      BaseArgs = args,
    };

  public IGqlpOutputArg EnumObjArg(string input, string enumLabel)
    => NewObjArgAst(input, false) with { EnumLabel = enumLabel };

  protected override OutputArgAst NewObjArgAst(string input, bool isTypeParam)
    => new(AstNulls.At, input) {
      IsTypeParam = isTypeParam,
    };
}

public interface IOutputBaseModelChecks
  : ICheckObjBaseModel<IGqlpOutputBase, IGqlpOutputArg, OutputBaseModel>
{
  string[] ExpectedEnumArgs(string[] arguments, string enumLabel);
  IGqlpOutputArg EnumObjArg(string input, string enumLabel);
}
