//HintName: test_Introspection_Dec.gen.cs
// Generated from {CurrentDirectory}Introspection.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

internal class test_NameDecoder : IDecoder<Itest_Name>
{

  public IMessages Decode(IValue input, out Itest_Name? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_NameDecoder Factory(IDecoderRepository _) => new();
}

internal class test_FilterDecoder : IDecoder<Itest_FilterObject>
{
  public ICollection<Itest_NameFilter>? Names { get; set; }
  public bool? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter>? Aliases { get; set; }
  public bool? ReturnByAlias { get; set; }
  public bool? ReturnReferencedTypes { get; set; }

  public IMessages Decode(IValue input, out Itest_FilterObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_FilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_NameFilterDecoder : IDecoder<Itest_NameFilter>
{

  public IMessages Decode(IValue input, out Itest_NameFilter? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_NameFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_CategoryFilterDecoder : IDecoder<Itest_CategoryFilterObject>
{
  public ICollection<test_Resolution>? Resolutions { get; set; }

  public IMessages Decode(IValue input, out Itest_CategoryFilterObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_CategoryFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeFilterDecoder : IDecoder<Itest_TypeFilterObject>
{
  public ICollection<test_TypeKind>? Kinds { get; set; }

  public IMessages Decode(IValue input, out Itest_TypeFilterObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_TypeFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_AliasedDecoder : IDecoder<Itest_AliasedObject>
{
  public ICollection<Itest_Name>? Aliases { get; set; }

  public IMessages Decode(IValue input, out Itest_AliasedObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_AliasedDecoder Factory(IDecoderRepository _) => new();
}

internal class test_NamedDecoder : IDecoder<Itest_NamedObject>
{
  public Itest_Name? Name { get; set; }

  public IMessages Decode(IValue input, out Itest_NamedObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_NamedDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DescribedDecoder : IDecoder<Itest_DescribedObject>
{
  public ICollection<string>? Description { get; set; }

  public IMessages Decode(IValue input, out Itest_DescribedObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_DescribedDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ResolutionDecoder : IDecoder<test_Resolution?>
{
  public IMessages Decode(IValue input, out test_Resolution? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_Resolution value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_Resolution".AnError();
  }

  internal static test_ResolutionDecoder Factory(IDecoderRepository _) => new();
}

internal class test_LocationDecoder : IDecoder<test_Location?>
{
  public IMessages Decode(IValue input, out test_Location? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_Location value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_Location".AnError();
  }

  internal static test_LocationDecoder Factory(IDecoderRepository _) => new();
}

internal class test_SimpleKindDecoder : IDecoder<test_SimpleKind?>
{
  public IMessages Decode(IValue input, out test_SimpleKind? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_SimpleKind value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_SimpleKind".AnError();
  }

  internal static test_SimpleKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeKindDecoder : IDecoder<test_TypeKind?>
{
  public IMessages Decode(IValue input, out test_TypeKind? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_TypeKind value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_TypeKind".AnError();
  }

  internal static test_TypeKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeRefDecoder<TTypeKind>
{
  public TTypeKind? TypeKind { get; set; }
}

internal class test_TypeSimpleDecoder : IDecoder<Itest_TypeSimpleObject>
{

  public IMessages Decode(IValue input, out Itest_TypeSimpleObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_TypeSimpleDecoder Factory(IDecoderRepository _) => new();
}

internal class test_CollectionsDecoder : IDecoder<Itest_CollectionsObject>
{

  public IMessages Decode(IValue input, out Itest_CollectionsObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_CollectionsDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierKeyedDecoder<TModifierKind>
{
  public Itest_TypeSimple? By { get; set; }
  public bool? IsOptional { get; set; }
}

internal class test_ModifiersDecoder : IDecoder<Itest_ModifiersObject>
{

  public IMessages Decode(IValue input, out Itest_ModifiersObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_ModifiersDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierKindDecoder : IDecoder<test_ModifierKind?>
{
  public IMessages Decode(IValue input, out test_ModifierKind? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_ModifierKind value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_ModifierKind".AnError();
  }

  internal static test_ModifierKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierDecoder<TModifierKind>
{
  public TModifierKind? ModifierKind { get; set; }
}

internal class test_DomainKindDecoder : IDecoder<test_DomainKind?>
{
  public IMessages Decode(IValue input, out test_DomainKind? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_DomainKind value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_DomainKind".AnError();
  }

  internal static test_DomainKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_BaseDomainItemDecoder : IDecoder<Itest_BaseDomainItemObject>
{
  public bool? Exclude { get; set; }

  public IMessages Decode(IValue input, out Itest_BaseDomainItemObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_BaseDomainItemDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainTrueFalseDecoder : IDecoder<Itest_DomainTrueFalseObject>
{
  public bool? Value { get; set; }

  public IMessages Decode(IValue input, out Itest_DomainTrueFalseObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_DomainTrueFalseDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainRangeDecoder : IDecoder<Itest_DomainRangeObject>
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }

  public IMessages Decode(IValue input, out Itest_DomainRangeObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_DomainRangeDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainRegexDecoder : IDecoder<Itest_DomainRegexObject>
{
  public string? Pattern { get; set; }

  public IMessages Decode(IValue input, out Itest_DomainRegexObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_DomainRegexDecoder Factory(IDecoderRepository _) => new();
}

internal class test_EnumLabelDecoder : IDecoder<Itest_EnumLabelObject>
{
  public Itest_Name? EnumType { get; set; }

  public IMessages Decode(IValue input, out Itest_EnumLabelObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_EnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ObjectKindDecoder : IDecoder<Itest_ObjectKind>
{
  public test_TypeKind? Value { get; set; }

  public IMessages Decode(IValue input, out Itest_ObjectKind? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_ObjectKindDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_IntrospectionDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_IntrospectionDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_Name>(test_NameDecoder.Factory)
      .AddDecoder<Itest_FilterObject>(test_FilterDecoder.Factory)
      .AddDecoder<Itest_NameFilter>(test_NameFilterDecoder.Factory)
      .AddDecoder<Itest_CategoryFilterObject>(test_CategoryFilterDecoder.Factory)
      .AddDecoder<Itest_TypeFilterObject>(test_TypeFilterDecoder.Factory)
      .AddDecoder<Itest_AliasedObject>(test_AliasedDecoder.Factory)
      .AddDecoder<Itest_NamedObject>(test_NamedDecoder.Factory)
      .AddDecoder<Itest_DescribedObject>(test_DescribedDecoder.Factory)
      .AddDecoder<test_Resolution?>(test_ResolutionDecoder.Factory)
      .AddDecoder<test_Location?>(test_LocationDecoder.Factory)
      .AddDecoder<test_SimpleKind?>(test_SimpleKindDecoder.Factory)
      .AddDecoder<test_TypeKind?>(test_TypeKindDecoder.Factory)
      .AddDecoder<Itest_TypeSimpleObject>(test_TypeSimpleDecoder.Factory)
      .AddDecoder<Itest_CollectionsObject>(test_CollectionsDecoder.Factory)
      .AddDecoder<Itest_ModifiersObject>(test_ModifiersDecoder.Factory)
      .AddDecoder<test_ModifierKind?>(test_ModifierKindDecoder.Factory)
      .AddDecoder<test_DomainKind?>(test_DomainKindDecoder.Factory)
      .AddDecoder<Itest_BaseDomainItemObject>(test_BaseDomainItemDecoder.Factory)
      .AddDecoder<Itest_DomainTrueFalseObject>(test_DomainTrueFalseDecoder.Factory)
      .AddDecoder<Itest_DomainRangeObject>(test_DomainRangeDecoder.Factory)
      .AddDecoder<Itest_DomainRegexObject>(test_DomainRegexDecoder.Factory)
      .AddDecoder<Itest_EnumLabelObject>(test_EnumLabelDecoder.Factory)
      .AddDecoder<Itest_ObjectKind>(test_ObjectKindDecoder.Factory);
}
