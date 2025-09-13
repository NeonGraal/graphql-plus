using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Objects;

public class OutputBaseModelTests(
  IOutputBaseModelChecks checks
) : TestObjBaseModel<IGqlpOutputBase, IGqlpObjArg, OutputBaseModel>(checks)
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
) : CheckObjBaseModel<IGqlpOutputBase, IGqlpObjArg, OutputBaseAst, OutputArgAst, OutputBaseModel>(modeller, encoding, TypeKindModel.Output)
  , IOutputBaseModelChecks
{
  public string[] ExpectedEnumArgs(string[] arguments, string enumLabel)
    => [.. ItemsExpected("typeArgs:", arguments,
      a => ["  - !_TypeRef(_SimpleKind)", "    label: " + enumLabel, "    name: " + a, "    typeKind: !_SimpleKind Enum"])];

  protected override OutputBaseAst NewObjBaseAst(string input, bool isTypeParam, IGqlpObjArg[] args)
    => new(AstNulls.At, input) {
      IsTypeParam = isTypeParam,
      BaseArgs = args,
    };

  public IGqlpObjArg EnumObjArg(string input, string enumLabel)
    => new OutputArgAst(AstNulls.At, input) { EnumLabel = enumLabel };

  protected override IGqlpObjArg NewObjArgAst(string input, bool isTypeParam)
    => new OutputArgAst(AstNulls.At, input) {
      IsTypeParam = isTypeParam,
    };
}

public interface IOutputBaseModelChecks
  : ICheckObjBaseModel<IGqlpOutputBase, IGqlpObjArg, OutputBaseModel>
{
  string[] ExpectedEnumArgs(string[] arguments, string enumLabel);
  IGqlpObjArg EnumObjArg(string input, string enumLabel);
}
