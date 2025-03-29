using GqlPlus.Abstractions.Schema;
using GqlPlus.Modelling;
using GqlPlus.Resolving;

namespace GqlPlus.Schema;

public abstract class TestTypeModel<TAstParent, TParent, TTypeKind, TRender>(
  ICheckTypeModel<TAstParent, TParent, TTypeKind, TRender> typeChecks
) : TestAliasedModel<string, TRender>(typeChecks)
  where TRender : IModelBase
{
  [Theory, RepeatData]
  public void Model_Parent(string name, TParent parent)
    => typeChecks.TypeExpected(
      typeChecks.TypeAst(name, parent),
      typeChecks.ExpectedType(new(name, parent)));
}

public abstract class TestTypeModel<TTypeKind, TRender>(
  ICheckTypeModel<TTypeKind, TRender> typeChecks
) : TestTypeModel<string, string, TTypeKind, TRender>(typeChecks)
  where TRender : IModelBase
{ }

internal abstract class CheckTypeModel<TAstParent, TParent, TAst, TTypeKind, TModel>(
  CheckTypeInputs<TAst, TModel> inputs,
  TTypeKind kind
) : CheckAliasedModel<string, TAst, TModel>(inputs.Modeller, inputs.Rendering)
  , ICheckTypeModel<TAstParent, TParent, TTypeKind, TModel>
  where TAst : IGqlpType<TAstParent>
  where TModel : IModelBase
{
  private readonly CheckTypeInputs<TAst, TModel> _inputs = inputs;
  protected readonly TTypeKind TypeKind = kind;
  protected readonly string TypeKindLower = $"{kind}".ToLowerInvariant();

  TTypeKind ICheckTypeModel<TAstParent, TParent, TTypeKind, TModel>.TypeKind => TypeKind;
  string ICheckTypeModel<TAstParent, TParent, TTypeKind, TModel>.TypeKindLower => TypeKindLower;

  protected override TModel AstToModel(TAst ast)
    => _inputs.Resolver.Resolve(base.AstToModel(ast), Context);

  protected abstract string[] ExpectedType(ExpectedTypeInput<TParent> input);

  protected abstract string[] ExpectedParent(TParent? parent);

  internal abstract TAst NewTypeAst(string name, TAstParent? parent = default, string? description = null, string[]? aliases = null);

  internal abstract TAstParent NewParentAst(TParent input);

  string[] ICheckTypeModel<TAstParent, TParent, TTypeKind, TModel>.ExpectedType(ExpectedTypeInput<TParent> input)
    => ExpectedType(input);

  TAstParent ICheckTypeModel<TAstParent, TParent, TTypeKind, TModel>.ParentAst(TParent parent)
    => NewParentAst(parent);
  IGqlpType<TAstParent> ICheckTypeModel<TAstParent, TParent, TTypeKind, TModel>.TypeAst(string name, TParent parent)
    => NewTypeAst(name, NewParentAst(parent), "");

  void ICheckTypeModel<TAstParent, TParent, TTypeKind, TModel>.TypeExpected(IGqlpType<TAstParent> type, string[] expected)
    => AstExpected((TAst)type, expected);

  protected override TAst NewAliasedAst(string input, string? description = null, string[]? aliases = null)
    => NewTypeAst(input, default, description, aliases);
  protected override string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<string> input)
    => ExpectedType(new(input));
}

internal abstract class CheckTypeModel<TAst, TTypeKind, TModel>(
  CheckTypeInputs<TAst, TModel> inputs,
  TTypeKind kind
) : CheckTypeModel<string, string, TAst, TTypeKind, TModel>(inputs, kind)
  , ICheckTypeModel<TTypeKind, TModel>
  where TAst : IGqlpType<string>
  where TModel : IModelBase
{
  internal override string NewParentAst(string input)
    => input;
}

public record class CheckTypeInputs<TAst, TModel>(
  IModeller<TAst, TModel> Modeller,
  IResolver<TModel> Resolver,
  IRenderer<TModel> Rendering
) where TAst : IGqlpError
  where TModel : IModelBase;

public interface ICheckTypeModel<TAstParent, TParent, TTypeKind, TRender>
  : ICheckAliasedModel<string, TRender>
  where TRender : IModelBase
{
  TTypeKind TypeKind { get; }
  string TypeKindLower { get; }
  void TypeExpected(IGqlpType<TAstParent> type, string[] expected);
  IGqlpType<TAstParent> TypeAst(string name, TParent parent);
  TAstParent ParentAst(TParent parent);
  string[] ExpectedType(ExpectedTypeInput<TParent> input);
}

public interface ICheckTypeModel<TTypeKind, TRender>
  : ICheckTypeModel<string, string, TTypeKind, TRender>
  where TRender : IModelBase
{ }

public interface IParentModel<TItem>
{
  BaseTypeModel NewParent(string name, TItem[] items, string? parent = null);
}

public class ExpectedTypeInput<TParent>(
  string name,
  TParent? parent = default,
  IEnumerable<string>? aliases = null,
  string? description = null)
  : ExpectedDescriptionAliasesInput<string>(name, aliases, description)
{
  internal TParent? Parent { get; } = parent;

  internal ExpectedTypeInput(ExpectedDescriptionAliasesInput<string> input)
    : this(input.Name)
  {
    Aliases = input.Aliases;
    ExpectedAliases = input.ExpectedAliases;
    Description = input.Description;
    ExpectedDescription = input.ExpectedDescription;
  }
}
