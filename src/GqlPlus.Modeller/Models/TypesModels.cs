﻿using System.Diagnostics.CodeAnalysis;
using GqlPlus.Resolving;

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
  where TParent : IModelBase
{
  public TParent? Parent { get; set; }

  internal IModelBase? _parentModel;

  protected abstract string? ParentName(TParent? parent);

  internal virtual bool GetParentModel<TResult>(IResolveContext context, [NotNullWhen(true)] out TResult? model)
    where TResult : IModelBase
  {
    if (_parentModel is null) {
      _parentModel = model = context.TryGetType(Name, ParentName(Parent), out TResult? parentModel) ? parentModel : default;
    } else {
      model = (TResult?)_parentModel;
    }

    return model is not null;
  }

  internal void ForParent<TResult>(IResolveContext context, Action<TResult> action)
    where TResult : IChildTypeModel
  {
    if (GetParentModel(context, out TResult? parentModel)) {
      parentModel.ForParent(context, action);
      action(parentModel);
    }
  }

  void IChildTypeModel.ForParent<TModel>(IResolveContext context, Action<TModel> action)
    => ForParent(context, action);
}

internal interface IChildTypeModel
  : IModelBase
{
  void ForParent<TModel>(IResolveContext context, Action<TModel> action)
    where TModel : IChildTypeModel;
}

public abstract record class ParentTypeModel<TItem, TAll>(
  TypeKindModel Kind,
  string Name
) : ChildTypeModel<TypeRefModel<SimpleKindModel>>(Kind, Name)
  where TItem : IModelBase
  where TAll : IModelBase
{
  public TItem[] Items { get; set; } = [];

  protected override string? ParentName(TypeRefModel<SimpleKindModel>? parent)
    => parent?.Name;

  protected abstract Func<TItem, TAll> NewItem(string parent);
}

public enum SimpleKindModel { Basic, Enum, Internal, Domain, Union, LastSimple = 9 }

public enum TypeKindModel
{
  Basic = SimpleKindModel.Basic,
  Enum = SimpleKindModel.Enum,
  Internal = SimpleKindModel.Internal,
  Domain = SimpleKindModel.Domain,
  Union = SimpleKindModel.Union,
  LastSimple = SimpleKindModel.LastSimple,
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
