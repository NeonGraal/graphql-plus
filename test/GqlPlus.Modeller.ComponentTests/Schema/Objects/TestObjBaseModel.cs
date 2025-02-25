using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Modelling;
using GqlPlus.Schema;

namespace GqlPlus.Schema.Objects;

public abstract class TestObjBaseModel<TObjBase, TObjArg, TModel>(
  ICheckObjBaseModel<TObjBase, TObjArg, TModel> objBaseChecks
) : TestModelBase<string, TModel>(objBaseChecks)
  where TObjBase : IGqlpObjBase
  where TObjArg : IGqlpObjArg
  where TModel : IModelBase
{
  [Theory, RepeatData(Repeats)]
  public void Model_Args(string name, string[] arguments)
    => objBaseChecks.ObjBase_Expected(
      objBaseChecks.ObjBaseAst(name, false, [.. arguments.Select(a => objBaseChecks.ObjArgAst(a, false))]),
      objBaseChecks.ExpectedObjBase(name, false, objBaseChecks.ExpectedArgs(arguments))
      );

  [Theory, RepeatData(Repeats)]
  public void Model_Dual(string name)
    => objBaseChecks
      .AddTypeKinds(TypeKindModel.Dual, name)
      .ObjBase_Expected(
      objBaseChecks.ObjBaseAst(name, false, []),
      objBaseChecks.ExpectedDual(name)
      );

  [Theory, RepeatData(Repeats)]
  public void Model_TypeParam(string name)
    => objBaseChecks.ObjBase_Expected(
      objBaseChecks.ObjBaseAst(name, true, []),
      objBaseChecks.ExpectedObjBase(name, true, [])
      );
}

internal abstract class CheckObjBaseModel<TObjBase, TObjArg, TObjBaseAst, TObjArgAst, TModel>(
  IModeller<TObjBase, TModel> objBase,
  IRenderer<TModel> rendering,
  TypeKindModel kind
) : CheckModelBase<string, TObjBase, TModel>(objBase, rendering),
    ICheckObjBaseModel<TObjBase, TObjArg, TModel>
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjArg>, TObjBase
  where TObjArg : IGqlpObjArg
  where TObjArgAst : AstObjArg, TObjArg
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
    ? ["!_TypeParam " + input]
    : [$"!_{TypeKind}Base", $"{TypeKindLower}: {input}", .. args];
  protected string[] ExpectedDual(string input)
    => ["!_DualBase", "dual: " + input];

  protected abstract TObjBaseAst NewObjBaseAst(string input, bool isTypeParam, TObjArg[] args);
  protected abstract TObjArg NewObjArgAst(string input, bool isTypeParam);

  void ICheckObjBaseModel<TObjBase, TObjArg, TModel>.ObjBase_Expected(TObjBase ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);
  TObjBase ICheckObjBaseModel<TObjBase, TObjArg, TModel>.ObjBaseAst(string input, bool isTypeParam, TObjArg[] args)
    => NewObjBaseAst(input, isTypeParam, args);
  string[] ICheckObjBaseModel<TObjBase, TObjArg, TModel>.ExpectedObjBase(string input, bool isTypeParam, string[] args)
    => ExpectedObjBase(input, isTypeParam, args);
  string[] ICheckObjBaseModel<TObjBase, TObjArg, TModel>.ExpectedDual(string input)
    => ExpectedDual(input);
  string[] ICheckObjBaseModel<TObjBase, TObjArg, TModel>.ExpectedArgs(string[] args)
    => [.. ItemsExpected("typeArgs:", args, a => [$"- !_{TypeKind}Arg", $"  {TypeKindLower}: {a}"])];
  TObjArg ICheckObjBaseModel<TObjBase, TObjArg, TModel>.ObjArgAst(string input, bool isTypeParam) => NewObjArgAst(input, isTypeParam);
}

public interface ICheckObjBaseModel<TObjBase, TObjArg, TModel>
  : ICheckModelBase<string, TModel>
  where TObjBase : IGqlpObjBase
  where TObjArg : IGqlpObjArg
  where TModel : IModelBase
{
  string[] ExpectedObjBase(string input, bool isTypeParam, string[] args);
  string[] ExpectedDual(string input);
  string[] ExpectedArgs(string[] args);
  void ObjBase_Expected(TObjBase ast, string[] expected);
  TObjBase ObjBaseAst(string input, bool isTypeParam, TObjArg[] args);
  TObjArg ObjArgAst(string input, bool isTypeParam);
}
