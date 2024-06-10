using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public abstract class TestObjBaseModel<TObjBase, TObjBaseAst>
  : TestModelBase<string>
  where TObjBase : IGqlpObjectBase<TObjBase>
  where TObjBaseAst : AstObjectBase<TObjBaseAst>, TObjBase
{
  [Theory, RepeatData(Repeats)]
  public void Model_Arguments(string name, string[] arguments)
    => ObjBaseChecks.ObjBase_Expected(
      ObjBaseChecks.ObjBaseAst(name) with { TypeArguments = [.. arguments.Select(ObjBaseChecks.ObjBaseAst)] },
      ObjBaseChecks.ExpectedObjBase(name, false, ObjBaseChecks.ExpectedArguments(arguments))
      );

  [Theory, RepeatData(Repeats)]
  public void Model_Dual(string name)
    => ObjBaseChecks
      .AddTypeKinds(TypeKindModel.Dual, name)
      .ObjBase_Expected(
      ObjBaseChecks.ObjBaseAst(name),
      ObjBaseChecks.ExpectedDual(name)
      );

  [Theory, RepeatData(Repeats)]
  public void Model_TypeParam(string name)
    => ObjBaseChecks.ObjBase_Expected(
      ObjBaseChecks.ObjBaseAst(name) with { IsTypeParameter = true },
      ObjBaseChecks.ExpectedObjBase(name, true, [])
      );

  internal override ICheckModelBase<string> BaseChecks => ObjBaseChecks;

  internal abstract ICheckObjBaseModel<TObjBaseAst> ObjBaseChecks { get; }
}

internal abstract class CheckObjBaseModel<TObjBase, TObjBaseAst, TModel>(
  IModeller<TObjBase, TModel> objBase,
  IRenderer<TModel> rendering,
  TypeKindModel kind
) : CheckModelBase<string, TObjBase, TModel>(objBase, rendering),
    ICheckObjBaseModel<TObjBaseAst>
  where TObjBase : IGqlpObjectBase<TObjBase>
  where TObjBaseAst : AstObjectBase<TObjBaseAst>, TObjBase
  where TModel : IModelBase
{
  protected readonly TypeKindModel TypeKind = kind;
  protected readonly string TypeKindLower = $"{kind}".ToLowerInvariant();

  protected override TObjBaseAst NewBaseAst(string input)
    => NewObjBaseAst(input);
  protected override string[] ExpectedBase(string input)
    => ExpectedObjBase(input, false, []);

  protected string[] ExpectedObjBase(string input, bool isTypeParam, string[] args)
    => isTypeParam
    ? ["!_TypeParameter " + input]
    : [$"!_{TypeKind}Base", $"{TypeKindLower}: {input}", .. args];
  protected string[] ExpectedDual(string input)
    => ["!_DualBase", "dual: " + input];

  protected abstract TObjBaseAst NewObjBaseAst(string name);

  void ICheckObjBaseModel<TObjBaseAst>.ObjBase_Expected(TObjBaseAst ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);
  TObjBaseAst ICheckObjBaseModel<TObjBaseAst>.ObjBaseAst(string name)
    => NewObjBaseAst(name);
  string[] ICheckObjBaseModel<TObjBaseAst>.ExpectedObjBase(string input, bool isTypeParam, string[] args)
    => ExpectedObjBase(input, isTypeParam, args);
  string[] ICheckObjBaseModel<TObjBaseAst>.ExpectedDual(string input)
    => ExpectedDual(input);
  string[] ICheckObjBaseModel<TObjBaseAst>.ExpectedArguments(string[] args)
    => [.. ItemsExpected("typeArguments:", args, a => [$"- !_{TypeKind}Base", $"  {TypeKindLower}: {a}"])];
}

internal interface ICheckObjBaseModel<TObjBaseAst>
  : ICheckModelBase<string>
  where TObjBaseAst : AstObjectBase<TObjBaseAst>
{
  string[] ExpectedObjBase(string input, bool isTypeParam, string[] args);
  string[] ExpectedDual(string input);
  string[] ExpectedArguments(string[] args);
  void ObjBase_Expected(TObjBaseAst ast, string[] expected);
  TObjBaseAst ObjBaseAst(string name);
}
