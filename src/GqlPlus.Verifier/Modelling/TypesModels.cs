using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

// TypeModel => BaseTypeModel

public abstract record class BaseTypeModel(
  TypeKindModel Kind,
  string Name
) : AliasedModel(Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
    .Add("kind", Kind.RenderEnum());
}

public abstract record class ChildTypeModel<TParent>(
  TypeKindModel Kind,
  string Name
) : BaseTypeModel(Kind, Name)
  where TParent : IRendering
{
  public TParent? Parent { get; set; }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("parent", Parent?.Render(context));

  internal void ForParent<TModel>(IRenderContext context, Func<TParent?, string?> parent, Action<TModel> action)
    where TModel : ChildTypeModel<TParent>
  {
    if (context.TryGetType<TModel>(parent(Parent), out var parentModel)) {
      parentModel.ForParent(context, parent, action);
      action(parentModel);
    }
  }
}
public abstract record class ParentTypeModel<TItem, TAll>(
  TypeKindModel Kind,
  string Name
) : ChildTypeModel<TypeRefModel<SimpleKindModel>>(Kind, Name)
  where TItem : IRendering
  where TAll : IRendering
{
  public TItem[] Items { get; set; } = [];

  protected abstract Func<TItem, TAll> NewItem(string parent);
  internal override RenderStructure Render(IRenderContext context)
  {
    List<TAll> all = [];
    void AddMembers(ParentTypeModel<TItem, TAll> model)
      => all.AddRange(model.Items.Select(NewItem(model.Name)));

    ForParent<ParentTypeModel<TItem, TAll>>(context, parent => parent?.Name, AddMembers);
    AddMembers(this);

    return base.Render(context)
        .Add("items", Items.Render(context))
        .Add("allItems", all.Render(context));
  }
}

public enum SimpleKindModel { Basic, Enum, Internal, Scalar, Union }

public enum TypeKindModel
{
  Basic = SimpleKindModel.Basic,
  Enum = SimpleKindModel.Enum,
  Internal = SimpleKindModel.Internal,
  Scalar = SimpleKindModel.Scalar,
  Union = SimpleKindModel.Union,
  Dual,
  Input,
  Output,
}

public record class TypeRefModel<TKind>(
  TKind Kind,
  string Name
) : NamedModel(Name)
{
  private static readonly string s_kindTag = typeof(TKind).TypeTag();

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("kind", new(Kind?.ToString(), s_kindTag));
}

public record class TypeSimpleModel(
  SimpleKindModel Kind,
  string Name
) : TypeRefModel<SimpleKindModel>(Kind, Name), IBaseScalarItemModel
{ }

internal abstract class ModellerType<TAst, TParent, TModel>(
  TypeKindModel kind
) : ModellerBase<TAst, TModel>, ITypeModeller
  where TAst : AstType<TParent>
  where TParent : IEquatable<TParent>
  where TModel : BaseTypeModel
{
  TypeKindModel ITypeModeller.Kind => kind;

  bool ITypeModeller.ForType(AstType ast)
    => ast is TAst;

  BaseTypeModel ITypeModeller.ToTypeModel(AstType ast, IMap<TypeKindModel> typeKinds)
    => ToModel((TAst)ast, typeKinds);
}

internal interface ITypeModeller
{
  bool ForType(AstType ast);
  TypeKindModel Kind { get; }
  BaseTypeModel ToTypeModel(AstType ast, IMap<TypeKindModel> typeKinds);
}

internal static class ModelHelper
{
  [return: NotNullIfNotNull(nameof(input))]
  internal static TypeRefModel<TKind>? TypeRef<TKind>(this string? input, TKind kind)
    => input is null ? null : new(kind, input);
}

internal class TypeModeller(
  IEnumerable<ITypeModeller> types
) : ModellerBase<AstType, BaseTypeModel>, ITypesModeller
{
  public void AddTypeKinds(IEnumerable<AstType> asts, IMap<TypeKindModel> typeKinds)
  {
    foreach (var ast in asts) {
      typeKinds.Add(ast.Name, types.Single(t => t.ForType(ast)).Kind);
    }
  }

  internal override BaseTypeModel ToModel(AstType ast, IMap<TypeKindModel> typeKinds)
    => types.Single(t => t.ForType(ast)).ToTypeModel(ast, typeKinds);
}

internal interface ITypesModeller
  : IModeller<AstType, BaseTypeModel>
{
  void AddTypeKinds(IEnumerable<AstType> asts, IMap<TypeKindModel> typeKinds);
}
