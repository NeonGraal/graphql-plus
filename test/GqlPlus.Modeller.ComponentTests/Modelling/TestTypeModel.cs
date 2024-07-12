using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Modelling;

public abstract class TestTypeModel<TAstParent, TParent, TTypeKind, TRender>(
  ICheckTypeModel<TAstParent, TParent, TTypeKind, TRender> typeChecks
) : TestAliasedModel<string, TRender>(typeChecks)
  where TRender : IModelBase
{
  [Theory, RepeatData(Repeats)]
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

internal abstract class CheckTypeModel<TAstParent, TParent, TAst, TTypeKind, TModel>
  : CheckAliasedModel<string, TAst, TModel>
  , ICheckTypeModel<TAstParent, TParent, TTypeKind, TModel>
  where TAst : IGqlpType<TAstParent>
  where TModel : IModelBase
{
  protected readonly TTypeKind TypeKind;
  protected readonly string TypeKindLower;

  TTypeKind ICheckTypeModel<TAstParent, TParent, TTypeKind, TModel>.TypeKind => TypeKind;
  string ICheckTypeModel<TAstParent, TParent, TTypeKind, TModel>.TypeKindLower => TypeKindLower;

  protected CheckTypeModel(IModeller<TAst, TModel> modeller, IRenderer<TModel> rendering, TTypeKind kind)
    : base(modeller, rendering)
    => (TypeKind, TypeKindLower) = (kind, $"{kind}".ToLowerInvariant());

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
  IModeller<TAst, TModel> modeller,
  IRenderer<TModel> rendering,
  TTypeKind kind
) : CheckTypeModel<string, string, TAst, TTypeKind, TModel>(modeller, rendering, kind)
  , ICheckTypeModel<TTypeKind, TModel>
  where TAst : IGqlpType<string>
  where TModel : IModelBase
{
  internal override string NewParentAst(string input)
    => input;
}

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
  BaseTypeModel NewParent(string name, TItem[] members, string? parent = null);
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
