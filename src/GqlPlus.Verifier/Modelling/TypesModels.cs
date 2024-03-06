﻿using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

// Todo: TypeModel

public abstract record class BaseTypeModel(
  TypeKindModel Kind,
  string Name
) : AliasedModel(Name)
{
  internal override RenderStructure Render()
    => base.Render()
    .Add("kind", Kind.RenderEnum());
}

public abstract record class ChildTypeModel<TParent>(
  TypeKindModel Kind,
  string Name
) : BaseTypeModel(Kind, Name)
  where TParent : IRendering
{
  public TParent? Parent { get; set; }

  internal override RenderStructure Render()
    => base.Render()
      .Add("parent", Parent?.Render());
}

public enum SimpleKindModel { Basic, Enum, Internal, Scalar }

public enum TypeKindModel
{
  Basic = SimpleKindModel.Basic,
  Enum = SimpleKindModel.Enum,
  Internal = SimpleKindModel.Internal,
  Scalar = SimpleKindModel.Scalar,
  Input,
  Output,
}

public record class TypeRefModel<TKind>(
  TKind Kind,
  string Name
) : NamedModel(Name)
{
  private static readonly string s_kindTag = typeof(TKind).TypeTag();

  internal override RenderStructure Render()
    => base.Render()
      .Add("kind", new(Kind?.ToString(), s_kindTag));
}

public record class TypeSimpleModel(
  SimpleKindModel Kind,
  string Name
) : TypeRefModel<SimpleKindModel>(Kind, Name), IBaseScalarItemModel
{ }

internal abstract class ModellerType<TAst, TParent, TModel>
  : ModellerBase<TAst, TModel>
  where TAst : AstType<TParent>
  where TParent : IEquatable<TParent>
  where TModel : IRendering
{ }

internal static class ModelHelper
{
  [return: NotNullIfNotNull(nameof(input))]
  internal static TypeRefModel<TKind>? TypeRef<TKind>(this string? input, TKind kind)
    => input is null ? null : new(kind, input);
}
