using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling.Objects;

public abstract class TestReferenceModel<TRef>
  : TestModelBase<string>
  where TRef : AstReference<TRef>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Arguments(string name, string[] arguments)
    => ReferenceChecks.Reference_Expected(
      ReferenceChecks.ReferenceAst(name) with { Arguments = [.. arguments.Select(ReferenceChecks.ReferenceAst)] },
      ReferenceChecks.ExpectedReference(name, false, ReferenceChecks.ExpectedArguments(arguments))
      );

  [Theory, RepeatData(Repeats)]
  public void Model_Dual(string name)
    => ReferenceChecks
      .AddTypeKinds(TypeKindModel.Dual, name)
      .Reference_Expected(
      ReferenceChecks.ReferenceAst(name),
      ReferenceChecks.ExpectedDual(name)
      );

  [Theory, RepeatData(Repeats)]
  public void Model_TypeParam(string name)
    => ReferenceChecks.Reference_Expected(
      ReferenceChecks.ReferenceAst(name) with { IsTypeParameter = true },
      ReferenceChecks.ExpectedReference(name, true, [])
      );

  internal override ICheckModelBase<string> BaseChecks => ReferenceChecks;

  internal abstract ICheckReferenceModel<TRef> ReferenceChecks { get; }
}

internal abstract class CheckReferenceModel<TRef, TModel>(
  IModeller<TRef, TModel> reference,
  TypeKindModel kind
) : CheckModelBase<string, TRef, TModel>(reference),
    ICheckReferenceModel<TRef>
  where TRef : AstReference<TRef>
  where TModel : IRendering
{
  protected readonly TypeKindModel TypeKind = kind;
  protected readonly string TypeKindLower = $"{kind}".ToLowerInvariant();

  protected override TRef NewBaseAst(string input)
    => NewReferenceAst(input);
  protected override string[] ExpectedBase(string input)
    => ExpectedReference(input, false, []);

  protected string[] ExpectedReference(string input, bool isTypeParam, string[] args)
    => isTypeParam
    ? ["!_TypeParameter " + input]
    : args.Length == 0
      ? [$"!_{TypeKind}Base {input}"]
      : [$"!_{TypeKind}Base", .. args, TypeKindLower + ": " + input];
  protected string[] ExpectedDual(string input)
    => ["!_DualBase " + input];

  protected abstract TRef NewReferenceAst(string name);

  void ICheckReferenceModel<TRef>.Reference_Expected(TRef ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected);
  TRef ICheckReferenceModel<TRef>.ReferenceAst(string name)
    => NewReferenceAst(name);
  string[] ICheckReferenceModel<TRef>.ExpectedReference(string input, bool isTypeParam, string[] args)
    => ExpectedReference(input, isTypeParam, args);
  string[] ICheckReferenceModel<TRef>.ExpectedDual(string input)
    => ExpectedDual(input);
  string[] ICheckReferenceModel<TRef>.ExpectedArguments(string[] args)
    => [.. ItemsExpected("arguments:", args, a => [$"- !_{TypeKind}Base {a}"])];
}

internal interface ICheckReferenceModel<TRef>
  : ICheckModelBase<string>
  where TRef : AstReference<TRef>
{
  string[] ExpectedReference(string input, bool isTypeParam, string[] args);
  string[] ExpectedDual(string input);
  string[] ExpectedArguments(string[] args);
  void Reference_Expected(TRef ast, string[] expected);
  TRef ReferenceAst(string name);
}
