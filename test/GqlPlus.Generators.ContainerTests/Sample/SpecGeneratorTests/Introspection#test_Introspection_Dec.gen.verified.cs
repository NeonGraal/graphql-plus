//HintName: test_Introspection_Dec.gen.cs
// Generated from {CurrentDirectory}Introspection.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

internal class test_NameDecoder
{
}

internal class test_FilterDecoder
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public bool? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public bool? ReturnByAlias { get; set; }
  public bool? ReturnReferencedTypes { get; set; }
}

internal class test_NameFilterDecoder
{
}

internal class test_CategoryFilterDecoder
{
  public ICollection<test_Resolution> Resolutions { get; set; }
}

internal class test_TypeFilterDecoder
{
  public ICollection<test_TypeKind> Kinds { get; set; }
}

internal class test_AliasedDecoder
{
  public ICollection<Itest_Name> Aliases { get; set; }
}

internal class test_NamedDecoder
{
  public Itest_Name Name { get; set; }
}

internal class test_DescribedDecoder
{
  public ICollection<string> Description { get; set; }
}

internal class test_ResolutionDecoder
{
  public string Parallel { get; set; }
  public string Sequential { get; set; }
  public string Single { get; set; }
}

internal class test_LocationDecoder
{
  public string Operation { get; set; }
  public string Variable { get; set; }
  public string Field { get; set; }
  public string Inline { get; set; }
  public string Spread { get; set; }
  public string Fragment { get; set; }
}

internal class test_SimpleKindDecoder
{
  public string Basic { get; set; }
  public string Enum { get; set; }
  public string Internal { get; set; }
  public string Domain { get; set; }
  public string Union { get; set; }
}

internal class test_TypeKindDecoder
{
  public string Basic { get; set; }
  public string Enum { get; set; }
  public string Internal { get; set; }
  public string Domain { get; set; }
  public string Union { get; set; }
  public string Dual { get; set; }
  public string Input { get; set; }
  public string Output { get; set; }
}

internal class test_TypeRefDecoder<TTypeKind>
{
  public TTypeKind TypeKind { get; set; }
}

internal class test_TypeSimpleDecoder
{
}

internal class test_CollectionsDecoder
{
}

internal class test_ModifierKeyedDecoder<TModifierKind>
{
  public Itest_TypeSimple By { get; set; }
  public bool IsOptional { get; set; }
}

internal class test_ModifiersDecoder
{
}

internal class test_ModifierKindDecoder
{
  public string Opt { get; set; }
  public string Optional { get; set; }
  public string List { get; set; }
  public string Dict { get; set; }
  public string Dictionary { get; set; }
  public string Param { get; set; }
  public string TypeParam { get; set; }
}

internal class test_ModifierDecoder<TModifierKind>
{
  public TModifierKind ModifierKind { get; set; }
}

internal class test_DomainKindDecoder
{
  public string Boolean { get; set; }
  public string Enum { get; set; }
  public string Number { get; set; }
  public string String { get; set; }
}

internal class test_BaseDomainItemDecoder
{
  public bool Exclude { get; set; }
}

internal class test_DomainTrueFalseDecoder
{
  public bool Value { get; set; }
}

internal class test_DomainRangeDecoder
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }
}

internal class test_DomainRegexDecoder
{
  public string Pattern { get; set; }
}

internal class test_EnumLabelDecoder
{
  public Itest_Name EnumType { get; set; }
}

internal class test_ObjectKindDecoder
{
}

internal static class test_IntrospectionDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_IntrospectionDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_Name>(_ => new test_NameDecoder())
      .AddDecoder<Itest_FilterObject>(r => new test_FilterDecoder(r))
      .AddDecoder<Itest_NameFilter>(_ => new test_NameFilterDecoder())
      .AddDecoder<Itest_CategoryFilterObject>(r => new test_CategoryFilterDecoder(r))
      .AddDecoder<Itest_TypeFilterObject>(r => new test_TypeFilterDecoder(r))
      .AddDecoder<Itest_AliasedObject>(r => new test_AliasedDecoder(r))
      .AddDecoder<Itest_NamedObject>(r => new test_NamedDecoder(r))
      .AddDecoder<Itest_DescribedObject>(r => new test_DescribedDecoder(r))
      .AddDecoder<test_Resolution>(_ => new test_ResolutionDecoder())
      .AddDecoder<test_Location>(_ => new test_LocationDecoder())
      .AddDecoder<test_SimpleKind>(_ => new test_SimpleKindDecoder())
      .AddDecoder<test_TypeKind>(_ => new test_TypeKindDecoder())
      .AddDecoder<Itest_TypeSimpleObject>(_ => new test_TypeSimpleDecoder())
      .AddDecoder<Itest_CollectionsObject>(_ => new test_CollectionsDecoder())
      .AddDecoder<Itest_ModifiersObject>(_ => new test_ModifiersDecoder())
      .AddDecoder<test_ModifierKind>(_ => new test_ModifierKindDecoder())
      .AddDecoder<test_DomainKind>(_ => new test_DomainKindDecoder())
      .AddDecoder<Itest_BaseDomainItemObject>(r => new test_BaseDomainItemDecoder(r))
      .AddDecoder<Itest_DomainTrueFalseObject>(r => new test_DomainTrueFalseDecoder(r))
      .AddDecoder<Itest_DomainRangeObject>(r => new test_DomainRangeDecoder(r))
      .AddDecoder<Itest_DomainRegexObject>(r => new test_DomainRegexDecoder(r))
      .AddDecoder<Itest_EnumLabelObject>(r => new test_EnumLabelDecoder(r))
      .AddDecoder<Itest_ObjectKind>(_ => new test_ObjectKindDecoder());
}
