using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class OutputBaseModelTests(
  IOutputBaseModelChecks checks
) : TestObjBaseModel<IGqlpOutputBase, IGqlpOutputArgument, OutputBaseModel>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void Model_EnumArguments(string name, string[] arguments, string enumMember)
    => checks.ObjBase_Expected(
      checks.ObjBaseAst(name, false, [.. arguments.Select(a => checks.EnumObjArg(a, enumMember))]),
      checks.ExpectedObjBase(name, false, checks.ExpectedEnumArguments(arguments, enumMember))
      );
}

internal sealed class OutputBaseModelChecks(
  IModeller<IGqlpOutputBase, OutputBaseModel> modeller,
  IRenderer<OutputBaseModel> rendering
) : CheckObjBaseModel<IGqlpOutputBase, IGqlpOutputArgument, OutputBaseAst, OutputArgumentAst, OutputBaseModel>(modeller, rendering, TypeKindModel.Output)
  , IOutputBaseModelChecks
{
  public string[] ExpectedEnumArguments(string[] arguments, string enumMember)
    => [.. ItemsExpected("typeArguments:", arguments,
      a => ["- !_OutputArgument", "  member: " + enumMember, "  name: " + a, "  typeKind: !_SimpleKind Enum"])];

  protected override OutputBaseAst NewObjBaseAst(string input, bool isTypeParam, IGqlpOutputArgument[] args)
    => new(AstNulls.At, input) {
      IsTypeParameter = isTypeParam,
      BaseArguments = args,
    };

  public IGqlpOutputArgument EnumObjArg(string input, string enumMember)
    => NewObjArgAst(input, false) with { EnumMember = enumMember };

  protected override OutputArgumentAst NewObjArgAst(string input, bool isTypeParam)
    => new(AstNulls.At, input) {
      IsTypeParameter = isTypeParam,
    };
}

public interface IOutputBaseModelChecks
  : ICheckObjBaseModel<IGqlpOutputBase, IGqlpOutputArgument, OutputBaseModel>
{
  string[] ExpectedEnumArguments(string[] arguments, string enumMember);
  IGqlpOutputArgument EnumObjArg(string input, string enumMember);
}
