using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Models;

// TypeModel => BaseTypeModel

public abstract record class BaseTypeModel(
  TypeKindModel TypeKind,
  string Name,
  string Description
) : AliasedModel(Name, Description)
{ }

public abstract record class ChildTypeModel<TParent>(
  TypeKindModel Kind,
  string Name,
  string Description
) : BaseTypeModel(Kind, Name, Description)
  where TParent : IModelBase
{
  public TParent? Parent { get; set; }

  internal IModelBase? ParentModel { get; set; }
}

public record class ParentTypeModel<TItem, TAll>(
  TypeKindModel Kind,
  string Name,
  string Description
) : ChildTypeModel<TypeRefModel<SimpleKindModel>>(Kind, Name, Description)
  where TItem : IModelBase
  where TAll : IModelBase
{
  public TItem[] Items { get; set; } = [];
  public TAll[] AllItems { get; set; } = [];
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
  Special = 19,
}

public record class TypeRefModel<TKind>(
  TKind TypeKind,
  string Name,
  string Description
) : NamedModel(Name, Description)
  , ITypeRefModel<TKind>
  where TKind : Enum
{ }

internal interface ITypeRefModel<TKind>
  : INamedModel
  where TKind : Enum
{
  TKind TypeKind { get; }
}

public record class SpecialTypeModel(
  string Name,
  string Description
) : BaseTypeModel(TypeKindModel.Special, Name, Description)
{ }

internal static class ModelHelper
{
  [return: NotNullIfNotNull(nameof(input))]
  internal static TypeRefModel<TKind>? TypeRef<TKind>(this string? input, TKind kind)
    where TKind : Enum
    => input is null ? null : new(kind, input, "");

  [return: NotNullIfNotNull(nameof(input))]
  internal static TypeRefModel<TKind>? TypeRef<TKind>(this IGqlpTypeRef? input, TKind kind)
    where TKind : Enum
    => input is null ? null : new(kind, input.Name, input.Description);
}
