using System.Diagnostics.CodeAnalysis;

using GqlPlus.Abstractions.Schema;
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
    if (_parentModel is null)
    {
      _parentModel = model = context.TryGetType<TModel>(Name, ParentName(Parent), out TModel? parentModel) ? parentModel : default;
    } else
    {
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
    if (GetParentModel<TModel>(context, out TModel? parentModel))
    {
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
  Special,
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

internal record class SpecialTypeModel(
  string Name
) : BaseTypeModel(TypeKindModel.Special, Name)
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

internal class TypesModeller(
  IEnumerable<ITypeModeller> types
) : ModellerBase<IGqlpType, BaseTypeModel>, ITypesModeller
{
  public void AddTypeKinds(IEnumerable<IGqlpType> asts, IMap<TypeKindModel> typeKinds)
  {
    foreach (IGqlpType ast in asts)
    {
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

  internal void AddTypes(IGqlpType[] asts, TypeKindModel kind)
  {
    foreach (IGqlpType ast in asts)
    {
      this[ast.Name] = kind;

      foreach (string alias in ast.Aliases)
      {
        TryAdd(alias, kind);
      }
    }

    foreach (IGqlpType ast in asts)
    {
      try
      {
        BaseTypeModel? model = types.TryModel(ast, this);
        if (model is not null)
        {
          Types[model.Name] = model;
          foreach (string alias in ast.Aliases)
          {
            Types.TryAdd(alias, model);
          }
        }
      } catch (InvalidOperationException) { }
    }
  }

  public void AddModels(IEnumerable<BaseTypeModel> models)
  {
    foreach (BaseTypeModel model in models)
    {
      Types.Add(model.Name, model);

      foreach (string alias in model.Aliases)
      {
        Types.TryAdd(alias, model);
      }
    }
  }

  public bool TryGetType<TModel>(string context, string? name, [NotNullWhen(true)] out TModel? model)
    where TModel : IRendering
  {
    if (name is not null)
    {
      if (Types.TryGetValue(name, out BaseTypeModel? type) && type is TModel modelType)
      {
        model = modelType;
        return true;
      }

      Errors.Add(new TokenMessage(TokenKind.End, 0, 0, "", $"In {context} can't get model for type '{name}'"));
    }

    model = default;
    return false;
  }
}

internal class SpecialTypeModeller()
  : ModellerType<IGqlpTypeSpecial, string, SpecialTypeModel>(TypeKindModel.Special)
{
  protected override SpecialTypeModel ToModel(IGqlpTypeSpecial ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name)
    {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
    };
}
