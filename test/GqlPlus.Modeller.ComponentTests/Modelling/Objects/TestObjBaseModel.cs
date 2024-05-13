using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public abstract class TestObjBaseModel<TObjBase>
  : TestModelBase<string>
  where TObjBase : AstObjectBase<TObjBase>
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

  internal abstract ICheckObjBaseModel<TObjBase> ObjBaseChecks { get; }
}

internal abstract class CheckObjBaseModel<TObjBase, TModel>(
  IModeller<TObjBase, TModel> objBase,
  TypeKindModel kind
) : CheckModelBase<string, TObjBase, TModel>(objBase),
    ICheckObjBaseModel<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
  where TModel : IRendering
{
  protected readonly TypeKindModel TypeKind = kind;
  protected readonly string TypeKindLower = $"{kind}".ToLowerInvariant();

  protected override TObjBase NewBaseAst(string input)
    => NewObjBaseAst(input);
  protected override string[] ExpectedBase(string input)
    => ExpectedObjBase(input, false, []);

  protected string[] ExpectedObjBase(string input, bool isTypeParam, string[] args)
    => isTypeParam
    ? ["!_TypeParameter " + input]
    : [$"!_{TypeKind}Base", $"{TypeKindLower}: {input}", .. args];
  protected string[] ExpectedDual(string input)
    => ["!_DualBase", "dual: " + input];

  protected abstract TObjBase NewObjBaseAst(string name);

  void ICheckObjBaseModel<TObjBase>.ObjBase_Expected(TObjBase ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);
  TObjBase ICheckObjBaseModel<TObjBase>.ObjBaseAst(string name)
    => NewObjBaseAst(name);
  string[] ICheckObjBaseModel<TObjBase>.ExpectedObjBase(string input, bool isTypeParam, string[] args)
    => ExpectedObjBase(input, isTypeParam, args);
  string[] ICheckObjBaseModel<TObjBase>.ExpectedDual(string input)
    => ExpectedDual(input);
  string[] ICheckObjBaseModel<TObjBase>.ExpectedArguments(string[] args)
    => [.. ItemsExpected("typeArguments:", args, a => [$"- !_{TypeKind}Base", $"  {TypeKindLower}: {a}"])];
}

internal interface ICheckObjBaseModel<TObjBase>
  : ICheckModelBase<string>
  where TObjBase : AstObjectBase<TObjBase>
{
  string[] ExpectedObjBase(string input, bool isTypeParam, string[] args);
  string[] ExpectedDual(string input);
  string[] ExpectedArguments(string[] args);
  void ObjBase_Expected(TObjBase ast, string[] expected);
  TObjBase ObjBaseAst(string name);
}
