using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public abstract class TestObjBaseModel<TObjBase, TObjArg>
  : TestModelBase<string>
  where TObjBase : IGqlpObjBase
  where TObjArg : IGqlpObjArgument
{
  [Theory, RepeatData(Repeats)]
  public void Model_Arguments(string name, string[] arguments)
    => ObjBaseChecks.ObjBase_Expected(
      ObjBaseChecks.ObjBaseAst(name, false, [.. arguments.Select(a => ObjBaseChecks.ObjArgAst(a, false))]),
      ObjBaseChecks.ExpectedObjBase(name, false, ObjBaseChecks.ExpectedArguments(arguments))
      );

  [Theory, RepeatData(Repeats)]
  public void Model_Dual(string name)
    => ObjBaseChecks
      .AddTypeKinds(TypeKindModel.Dual, name)
      .ObjBase_Expected(
      ObjBaseChecks.ObjBaseAst(name, false, []),
      ObjBaseChecks.ExpectedDual(name)
      );

  [Theory, RepeatData(Repeats)]
  public void Model_TypeParam(string name)
    => ObjBaseChecks.ObjBase_Expected(
      ObjBaseChecks.ObjBaseAst(name, true, []),
      ObjBaseChecks.ExpectedObjBase(name, true, [])
      );

  internal override ICheckModelBase<string> BaseChecks => ObjBaseChecks;

  internal abstract ICheckObjBaseModel<TObjBase, TObjArg> ObjBaseChecks { get; }
}

internal abstract class CheckObjBaseModel<TObjBase, TObjArg, TObjBaseAst, TObjArgAst, TModel>(
  IModeller<TObjBase, TModel> objBase,
  IRenderer<TModel> rendering,
  TypeKindModel kind
) : CheckModelBase<string, TObjBase, TModel>(objBase, rendering),
    ICheckObjBaseModel<TObjBase, TObjArg>
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjArg>, TObjBase
  where TObjArg : IGqlpObjArgument
  where TObjArgAst : AstObjArgument, TObjArg
  where TModel : IModelBase
{
  protected readonly TypeKindModel TypeKind = kind;
  protected readonly string TypeKindLower = $"{kind}".ToLowerInvariant();

  protected override TObjBaseAst NewBaseAst(string input)
    => NewObjBaseAst(input, false, []);
  protected override string[] ExpectedBase(string input)
    => ExpectedObjBase(input, false, []);

  protected string[] ExpectedObjBase(string input, bool isTypeParam, string[] args)
    => isTypeParam
    ? ["!_TypeParameter " + input]
    : [$"!_{TypeKind}Base", $"{TypeKindLower}: {input}", .. args];
  protected string[] ExpectedDual(string input)
    => ["!_DualBase", "dual: " + input];

  protected abstract TObjBaseAst NewObjBaseAst(string input, bool isTypeParam, TObjArg[] args);
  protected abstract TObjArg NewObjArgAst(string input, bool isTypeParam);

  void ICheckObjBaseModel<TObjBase, TObjArg>.ObjBase_Expected(TObjBase ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);
  TObjBase ICheckObjBaseModel<TObjBase, TObjArg>.ObjBaseAst(string input, bool isTypeParam, TObjArg[] args)
    => NewObjBaseAst(input, isTypeParam, args);
  string[] ICheckObjBaseModel<TObjBase, TObjArg>.ExpectedObjBase(string input, bool isTypeParam, string[] args)
    => ExpectedObjBase(input, isTypeParam, args);
  string[] ICheckObjBaseModel<TObjBase, TObjArg>.ExpectedDual(string input)
    => ExpectedDual(input);
  string[] ICheckObjBaseModel<TObjBase, TObjArg>.ExpectedArguments(string[] args)
    => [.. ItemsExpected("typeArguments:", args, a => [$"- !_{TypeKind}Argument", $"  {TypeKindLower}: {a}"])];
  TObjArg ICheckObjBaseModel<TObjBase, TObjArg>.ObjArgAst(string input, bool isTypeParam) => NewObjArgAst(input, isTypeParam);
}

internal interface ICheckObjBaseModel<TObjBase, TObjArg>
  : ICheckModelBase<string>
  where TObjBase : IGqlpObjBase
  where TObjArg : IGqlpObjArgument
{
  string[] ExpectedObjBase(string input, bool isTypeParam, string[] args);
  string[] ExpectedDual(string input);
  string[] ExpectedArguments(string[] args);
  void ObjBase_Expected(TObjBase ast, string[] expected);
  TObjBase ObjBaseAst(string input, bool isTypeParam, TObjArg[] args);
  TObjArg ObjArgAst(string input, bool isTypeParam);
}
