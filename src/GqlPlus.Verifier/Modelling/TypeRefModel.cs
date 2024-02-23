﻿using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class TypeRefModel<TKind>(TKind Kind, string Name)
  : NamedModel(Name)
{
  private static readonly string s_kindTag = typeof(TKind).TypeTag();

  internal override RenderStructure Render()
    => base.Render()
      .Add("kind", new(s_kindTag, Kind?.ToString()));
}

internal enum SimpleKindModel { Basic, Enum, Internal, Scalar }

internal enum TypeKindModel
{
  Basic = SimpleKindModel.Basic,
  Enum = SimpleKindModel.Enum,
  Internal = SimpleKindModel.Internal,
  Scalar = SimpleKindModel.Scalar,
  Input,
  Output,
}

internal static class ModelHelper
{
  [return: NotNullIfNotNull(nameof(input))]
  internal static TypeRefModel<TKind>? TypeRef<TKind>(this string? input, TKind kind)
    => input is null ? null : new(kind, input);
}
