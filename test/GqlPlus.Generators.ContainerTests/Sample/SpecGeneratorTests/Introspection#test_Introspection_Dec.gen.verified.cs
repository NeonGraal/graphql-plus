//HintName: test_Introspection_Dec.gen.cs
// Generated from {CurrentDirectory}Introspection.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

internal class test_NameDecoder
{

  internal static test_NameDecoder Factory(IDecoderRepository _) => new();
}

internal class test_FilterDecoder
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public bool? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public bool? ReturnByAlias { get; set; }
  public bool? ReturnReferencedTypes { get; set; }

  internal static test_FilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_NameFilterDecoder
{

  internal static test_NameFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_CategoryFilterDecoder
{
  public ICollection<test_Resolution> Resolutions { get; set; }

  internal static test_CategoryFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeFilterDecoder
{
  public ICollection<test_TypeKind> Kinds { get; set; }

  internal static test_TypeFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_AliasedDecoder
{
  public ICollection<Itest_Name> Aliases { get; set; }

  internal static test_AliasedDecoder Factory(IDecoderRepository _) => new();
}

internal class test_NamedDecoder
{
  public Itest_Name Name { get; set; }

  internal static test_NamedDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DescribedDecoder
{
  public ICollection<string> Description { get; set; }

  internal static test_DescribedDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ResolutionDecoder
{
  public string Parallel { get; set; }
  public string Sequential { get; set; }
  public string Single { get; set; }

  internal static test_ResolutionDecoder Factory(IDecoderRepository _) => new();
}

internal class test_LocationDecoder
{
  public string Operation { get; set; }
  public string Variable { get; set; }
  public string Field { get; set; }
  public string Inline { get; set; }
  public string Spread { get; set; }
  public string Fragment { get; set; }

  internal static test_LocationDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpDirectiveDecoder
{
  public Itest_OpArgument? Argument { get; set; }

  internal static test_OpDirectiveDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgumentDecoder
{

  internal static test_OpArgumentDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgValueDecoder
{
  public Itest_Name Variable { get; set; }

  internal static test_OpArgValueDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgListDecoder
{

  internal static test_OpArgListDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgMapDecoder
{
  public Itest_OpArgValue Value { get; set; }
  public Itest_Name ByVariable { get; set; }

  internal static test_OpArgMapDecoder Factory(IDecoderRepository _) => new();
}

internal class test_PathDecoder
{

  internal static test_PathDecoder Factory(IDecoderRepository _) => new();
}

internal class test_SimpleKindDecoder
{
  public string Basic { get; set; }
  public string Enum { get; set; }
  public string Internal { get; set; }
  public string Domain { get; set; }
  public string Union { get; set; }

  internal static test_SimpleKindDecoder Factory(IDecoderRepository _) => new();
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

  internal static test_TypeKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeRefDecoder<TTypeKind>
{
  public TTypeKind TypeKind { get; set; }
}

internal class test_TypeSimpleDecoder
{

  internal static test_TypeSimpleDecoder Factory(IDecoderRepository _) => new();
}

internal class test_CollectionsDecoder
{

  internal static test_CollectionsDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierKeyedDecoder<TModifierKind>
{
  public Itest_TypeSimple By { get; set; }
  public bool IsOptional { get; set; }
}

internal class test_ModifiersDecoder
{

  internal static test_ModifiersDecoder Factory(IDecoderRepository _) => new();
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

  internal static test_ModifierKindDecoder Factory(IDecoderRepository _) => new();
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

  internal static test_DomainKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_BaseDomainItemDecoder
{
  public bool Exclude { get; set; }

  internal static test_BaseDomainItemDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainTrueFalseDecoder
{
  public bool Value { get; set; }

  internal static test_DomainTrueFalseDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainRangeDecoder
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }

  internal static test_DomainRangeDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainRegexDecoder
{
  public string Pattern { get; set; }

  internal static test_DomainRegexDecoder Factory(IDecoderRepository _) => new();
}

internal class test_EnumLabelDecoder
{
  public Itest_Name EnumType { get; set; }

  internal static test_EnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ObjectKindDecoder
{

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
      .AddDecoder<test_Resolution>(test_ResolutionDecoder.Factory)
      .AddDecoder<test_Location>(test_LocationDecoder.Factory)
      .AddDecoder<Itest_OpDirectiveObject>(test_OpDirectiveDecoder.Factory)
      .AddDecoder<Itest_OpArgumentObject>(test_OpArgumentDecoder.Factory)
      .AddDecoder<Itest_OpArgValueObject>(test_OpArgValueDecoder.Factory)
      .AddDecoder<Itest_OpArgListObject>(test_OpArgListDecoder.Factory)
      .AddDecoder<Itest_OpArgMapObject>(test_OpArgMapDecoder.Factory)
      .AddDecoder<Itest_Path>(test_PathDecoder.Factory)
      .AddDecoder<test_SimpleKind>(test_SimpleKindDecoder.Factory)
      .AddDecoder<test_TypeKind>(test_TypeKindDecoder.Factory)
      .AddDecoder<Itest_TypeSimpleObject>(test_TypeSimpleDecoder.Factory)
      .AddDecoder<Itest_CollectionsObject>(test_CollectionsDecoder.Factory)
      .AddDecoder<Itest_ModifiersObject>(test_ModifiersDecoder.Factory)
      .AddDecoder<test_ModifierKind>(test_ModifierKindDecoder.Factory)
      .AddDecoder<test_DomainKind>(test_DomainKindDecoder.Factory)
      .AddDecoder<Itest_BaseDomainItemObject>(test_BaseDomainItemDecoder.Factory)
      .AddDecoder<Itest_DomainTrueFalseObject>(test_DomainTrueFalseDecoder.Factory)
      .AddDecoder<Itest_DomainRangeObject>(test_DomainRangeDecoder.Factory)
      .AddDecoder<Itest_DomainRegexObject>(test_DomainRegexDecoder.Factory)
      .AddDecoder<Itest_EnumLabelObject>(test_EnumLabelDecoder.Factory)
      .AddDecoder<Itest_ObjectKind>(test_ObjectKindDecoder.Factory);
}
