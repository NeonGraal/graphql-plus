using System.Diagnostics.CodeAnalysis;

using GqlPlus.Modelling;

namespace GqlPlus.Models;

// TypeModel => BaseTypeModel

public abstract record class BaseTypeModel(
  TypeKindModel TypeKind,
  string Name
) : AliasedModel(Name)
{ }

public abstract record class ChildTypeModel<TParent>(
  TypeKindModel Kind,
  string Name
) : BaseTypeModel(Kind, Name)
  , IChildTypeModel
  where TParent : IRendering
{
  public TParent? Parent { get; set; }

  internal IRendering? _parentModel;

  protected abstract string? ParentName(TParent? parent);

  internal virtual bool GetParentModel<TResult>(IRenderContext context, [NotNullWhen(true)] out TResult? model)
    where TResult : IRendering
  {
    if (_parentModel is null) {
      _parentModel = model = context.TryGetType(Name, ParentName(Parent), out TResult? parentModel) ? parentModel : default;
    } else {
      model = (TResult?)_parentModel;
    }

    return model is not null;
  }

  internal void ForParent<TResult>(IRenderContext context, Action<TResult> action)
    where TResult : IChildTypeModel
  {
    if (GetParentModel(context, out TResult? parentModel)) {
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
  where TKind : struct
{ }

internal record class SpecialTypeModel(
  string Name
) : BaseTypeModel(TypeKindModel.Special, Name)
{ }

internal static class ModelHelper
{
  [return: NotNullIfNotNull(nameof(input))]
  internal static TypeRefModel<TKind>? TypeRef<TKind>(this string? input, TKind kind)
    where TKind : struct
    => input is null ? null : new(kind, input);
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
    foreach (IGqlpType ast in asts) {
      this[ast.Name] = kind;

      foreach (string alias in ast.Aliases) {
        TryAdd(alias, kind);
      }
    }

    foreach (IGqlpType ast in asts) {
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
