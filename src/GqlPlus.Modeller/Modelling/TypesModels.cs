using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling;

// TypeModel => BaseTypeModel

public abstract record class BaseTypeModel(
  TypeKindModel TypeKind,
  string Name
) : AliasedModel(Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
    .Add("typeKind", TypeKind.RenderEnum());
}

public abstract record class ChildTypeModel<TParent>(
  TypeKindModel Kind,
  string Name
) : BaseTypeModel(Kind, Name)
  , IChildTypeModel
  where TParent : IRendering
{
  public TParent? Parent { get; set; }

  private IRendering? _parentModel;

  protected abstract string? ParentName(TParent? parent);

  internal virtual bool GetParentModel<TModel>(IRenderContext context, [NotNullWhen(true)] out TModel? model)
    where TModel : IRendering
  {
    if (_parentModel is null) {
      _parentModel = model = context.TryGetType<TModel>(Name, ParentName(Parent), out TModel? parentModel) ? parentModel : default;
    } else {
      model = (TModel?)_parentModel;
    }

    return model is not null;
  }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("parent", Parent?.Render(context));

  internal void ForParent<TModel>(IRenderContext context, Action<TModel> action)
    where TModel : IChildTypeModel
  {
    if (GetParentModel<TModel>(context, out TModel? parentModel)) {
      parentModel.ForParent(context, action);
      action(parentModel);
    }
  }

  void IChildTypeModel.ForParent<TModel>(IRenderContext context, Action<TModel> action)
    => ForParent(context, action);
}

internal interface IChildTypeModel
  : IRendering
{
  void ForParent<TModel>(IRenderContext context, Action<TModel> action)
    where TModel : IChildTypeModel;
}

public abstract record class ParentTypeModel<TItem, TAll>(
  TypeKindModel Kind,
  string Name
) : ChildTypeModel<TypeRefModel<SimpleKindModel>>(Kind, Name)
  where TItem : IRendering
  where TAll : IRendering
{
  public TItem[] Items { get; set; } = [];

  protected override string? ParentName(TypeRefModel<SimpleKindModel>? parent)
    => parent?.Name;

  protected abstract Func<TItem, TAll> NewItem(string parent);
  internal override RenderStructure Render(IRenderContext context)
  {
    List<TAll> all = [];
    void AddMembers(ParentTypeModel<TItem, TAll> model)
      => all.AddRange(model.Items.Select(NewItem(model.Name)));

    ForParent<ParentTypeModel<TItem, TAll>>(context, AddMembers);
    AddMembers(this);

    return base.Render(context)
        .Add("items", Items.Render(context))
        .Add("allItems", all.Render(context));
  }
}

public enum SimpleKindModel { Basic, Enum, Internal, Domain, Union }

public enum TypeKindModel
{
  Basic = SimpleKindModel.Basic,
  Enum = SimpleKindModel.Enum,
  Internal = SimpleKindModel.Internal,
  Domain = SimpleKindModel.Domain,
  Union = SimpleKindModel.Union,
  Dual,
  Input,
  Output,
}

public record class TypeRefModel<TKind>(
  TKind TypeKind,
  string Name
) : NamedModel(Name)
{
  private static readonly string s_typeKindTag = typeof(TKind).TypeTag();

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("typeKind", new(TypeKind?.ToString(), s_typeKindTag));
}

public record class TypeSimpleModel(
  SimpleKindModel Kind,
  string Name
) : TypeRefModel<SimpleKindModel>(Kind, Name), IBaseDomainItemModel
{ }

internal abstract class ModellerType<TAst, TParent, TModel>(
  TypeKindModel kind
) : ModellerBase<TAst, TModel>, ITypeModeller
  where TAst : IGqlpType<TParent>
  where TParent : IEquatable<TParent>
  where TModel : BaseTypeModel
{
  TypeKindModel ITypeModeller.Kind => kind;

  bool ITypeModeller.ForType(IGqlpType ast)
    => ast is TAst;

  BaseTypeModel ITypeModeller.ToTypeModel(IGqlpType ast, IMap<TypeKindModel> typeKinds)
    => ToModel((TAst)ast, typeKinds);
}

internal interface ITypeModeller
{
  bool ForType(IGqlpType ast);
  TypeKindModel Kind { get; }
  BaseTypeModel ToTypeModel(IGqlpType ast, IMap<TypeKindModel> typeKinds);
}

internal static class ModelHelper
{
  [return: NotNullIfNotNull(nameof(input))]
  internal static TypeRefModel<TKind>? TypeRef<TKind>(this string? input, TKind kind)
    => input is null ? null : new(kind, input);
}

internal class TypeModeller(
  IEnumerable<ITypeModeller> types
) : ModellerBase<IGqlpType, BaseTypeModel>, ITypesModeller
{
  public void AddTypeKinds(IEnumerable<IGqlpType> asts, IMap<TypeKindModel> typeKinds)
  {
    foreach (IGqlpType ast in asts) {
      typeKinds.Add(ast.Name, types.Single(t => t.ForType(ast)).Kind);
    }
  }

  public TypeKindModel GetTypeKind(IGqlpType ast)
    => types.Single(t => t.ForType(ast)).Kind;

  protected override BaseTypeModel ToModel(IGqlpType ast, IMap<TypeKindModel> typeKinds)
    => types.Single(t => t.ForType(ast)).ToTypeModel(ast, typeKinds);
}

public interface ITypesModeller
  : IModeller<IGqlpType, BaseTypeModel>
{
  void AddTypeKinds(IEnumerable<IGqlpType> asts, IMap<TypeKindModel> typeKinds);
  TypeKindModel GetTypeKind(IGqlpType ast);
}

internal class TypesCollection(
  ITypesModeller types
) : Map<TypeKindModel>
  , IRenderContext
{
  internal IMap<BaseTypeModel> Types { get; } = new Map<BaseTypeModel>();
  internal ITokenMessages Errors { get; } = new TokenMessages();

  internal static TypesCollection WithBuiltins(ITypesModeller types)
  {
    TypesCollection typeKinds = new(types);

    typeKinds.AddTypes(BuiltIn.Basic, TypeKindModel.Basic);
    typeKinds.AddTypes(BuiltIn.Internal, TypeKindModel.Internal);

    return typeKinds;
  }

  internal void AddTypes(AstType[] asts, TypeKindModel kind)
  {
    foreach (AstType ast in asts) {
      this[ast.Name] = kind;

      foreach (string alias in ast.Aliases) {
        TryAdd(alias, kind);
      }
    }

    foreach (AstType ast in asts) {
      try {
        BaseTypeModel? model = types.TryModel(ast, this);
        if (model is not null) {
          Types[model.Name] = model;
          foreach (string alias in ast.Aliases) {
            Types.TryAdd(alias, model);
          }
        }
      } catch (InvalidOperationException) { }
    }
  }

  //internal void AddTypes(IEnumerable<AstType> toAdd)
  //{
  //  var asts = toAdd.ToArray();

  //  AddTypeAndAliasKinds(types, asts);

  //  foreach (var ast in asts) {
  //    if (Types.TryGetValue(ast.Name, out var existing) && existing.Name == ast.Name) {
  //      Errors.Add(new TokenMessage(TokenKind.End, 0, 0, "", $"Type {ast.Name} allready exists in collection"));
  //      continue;
  //    }

  //    var model = types.TryModel(ast, this);
  //    if (model is not null) {
  //      Types[model.Name] = model;
  //      foreach (var alias in ast.Aliases) {
  //        Types.TryAdd(alias, model);
  //      }
  //    }
  //  }
  //}

  //private void AddTypeAndAliasKinds(ITypesModeller types, AstType[] asts)
  //{
  //  foreach (var ast in asts) {
  //    var kind = types.GetTypeKind(ast);
  //    if (Types.TryGetValue(ast.Name, out var existing) && existing.Name == ast.Name) {
  //      if (existing.Kind != kind) {
  //        Errors.Add(new TokenMessage(TokenKind.End, 0, 0, "", $"Type {ast.Name}({kind} already exists with different kind ({existing.Kind}) in collection"));
  //      }

  //      continue;
  //    }

  //    this[ast.Name] = kind;

  //    foreach (var alias in ast.Aliases) {
  //      TryAdd(alias, kind);
  //    }
  //  }
  //}

  public void AddModels(IEnumerable<BaseTypeModel> models)
  {
    foreach (BaseTypeModel model in models) {
      Types.Add(model.Name, model);

      foreach (string alias in model.Aliases) {
        Types.TryAdd(alias, model);
      }
    }
  }

  public bool TryGetType<TModel>(string context, string? name, [NotNullWhen(true)] out TModel? model)
    where TModel : IRendering
  {
    if (name is not null) {
      if (Types.TryGetValue(name, out BaseTypeModel? type) && type is TModel modelType) {
        model = modelType;
        return true;
      }

      Errors.Add(new TokenMessage(TokenKind.End, 0, 0, "", $"In {context} can't get model for type '{name}'"));
    }

    model = default;
    return false;
  }
}
