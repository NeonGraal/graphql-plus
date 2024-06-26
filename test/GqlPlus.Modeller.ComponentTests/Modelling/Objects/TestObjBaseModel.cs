using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public abstract class TestObjBaseModel<TObjBase>
  : TestModelBase<string>
  where TObjBase : IGqlpObjBase
{
  [Theory, RepeatData(Repeats)]
  public void Model_Arguments(string name, string[] arguments)
    => ObjBaseChecks.ObjBase_Expected(
      ObjBaseChecks.ObjBaseAst(name, false, [.. arguments.Select(a => ObjBaseChecks.ObjBaseAst(a, false, []))]),
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

  internal abstract ICheckObjBaseModel<TObjBase> ObjBaseChecks { get; }
}

internal abstract class CheckObjBaseModel<TObjBase, TObjBaseAst, TModel>(
  IModeller<TObjBase, TModel> objBase,
  IRenderer<TModel> rendering,
  TypeKindModel kind
) : CheckModelBase<string, TObjBase, TModel>(objBase, rendering),
    ICheckObjBaseModel<TObjBase>
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjBase>, TObjBase
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

  protected abstract TObjBaseAst NewObjBaseAst(string input, bool isTypeParam, TObjBase[] args);

  void ICheckObjBaseModel<TObjBase>.ObjBase_Expected(TObjBase ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);
  TObjBase ICheckObjBaseModel<TObjBase>.ObjBaseAst(string input, bool isTypeParam, TObjBase[] args)
    => NewObjBaseAst(input, isTypeParam, args);
  string[] ICheckObjBaseModel<TObjBase>.ExpectedObjBase(string input, bool isTypeParam, string[] args)
    => ExpectedObjBase(input, isTypeParam, args);
  string[] ICheckObjBaseModel<TObjBase>.ExpectedDual(string input)
    => ExpectedDual(input);
  string[] ICheckObjBaseModel<TObjBase>.ExpectedArguments(string[] args)
    => [.. ItemsExpected("typeArguments:", args, a => [$"- !_{TypeKind}Base", $"  {TypeKindLower}: {a}"])];
}

internal interface ICheckObjBaseModel<TObjBase>
  : ICheckModelBase<string>
  where TObjBase : IGqlpObjBase
{
  string[] ExpectedObjBase(string input, bool isTypeParam, string[] args);
  string[] ExpectedDual(string input);
  string[] ExpectedArguments(string[] args);
  void ObjBase_Expected(TObjBase ast, string[] expected);
  TObjBase ObjBaseAst(string input, bool isTypeParam, TObjBase[] args);
}
