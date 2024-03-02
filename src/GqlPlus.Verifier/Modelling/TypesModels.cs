using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

// Todo: TypeModel

internal abstract record class BaseTypeModel(TypeKindModel Kind, string Name)
  : AliasedModel(Name)
{
  internal override RenderStructure Render()
    => base.Render()
    .Add("kind", Kind.RenderEnum());
}

internal abstract record class ChildTypeModel<TParent>(
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

internal record class TypeRefModel<TKind>(TKind Kind, string Name)
  : NamedModel(Name)
{
  private static readonly string s_kindTag = typeof(TKind).TypeTag();

  internal override RenderStructure Render()
    => base.Render()
      .Add("kind", new(Kind?.ToString(), s_kindTag));
}

internal record class TypeSimpleModel(SimpleKindModel Kind, string Name)
  : TypeRefModel<SimpleKindModel>(Kind, Name), IBaseScalarItemModel
{ }

internal static class ModelHelper
{
  [return: NotNullIfNotNull(nameof(input))]
  internal static TypeRefModel<TKind>? TypeRef<TKind>(this string? input, TKind kind)
    => input is null ? null : new(kind, input);
}
