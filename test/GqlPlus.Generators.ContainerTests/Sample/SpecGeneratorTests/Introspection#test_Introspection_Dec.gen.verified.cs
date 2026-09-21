//HintName: test_Introspection_Dec.gen.cs
// Generated from {CurrentDirectory}Introspection.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

internal class test_NameDecoder : NullDecoder<Itest_Name>
{

  internal static test_NameDecoder Factory(IDecoderRepository _) => new();
}

internal class test_FilterDecoder : NullDecoder<Itest_FilterObject>
{
  public ICollection<Itest_NameFilter> Names { get; set; } = default!;
  public bool? MatchAliases { get; set; } = default!;
  public ICollection<Itest_NameFilter> Aliases { get; set; } = default!;
  public bool? ReturnByAlias { get; set; } = default!;
  public bool? ReturnReferencedTypes { get; set; } = default!;

  internal static test_FilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_NameFilterDecoder : NullDecoder<Itest_NameFilter>
{

  internal static test_NameFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_CategoryFilterDecoder : NullDecoder<Itest_CategoryFilterObject>
{
  public ICollection<test_Resolution> Resolutions { get; set; } = default!;

  internal static test_CategoryFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeFilterDecoder : NullDecoder<Itest_TypeFilterObject>
{
  public ICollection<test_TypeKind> Kinds { get; set; } = default!;

  internal static test_TypeFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class test_AliasedDecoder : NullDecoder<Itest_AliasedObject>
{
  public ICollection<Itest_Name> Aliases { get; set; } = default!;

  internal static test_AliasedDecoder Factory(IDecoderRepository _) => new();
}

internal class test_NamedDecoder : NullDecoder<Itest_NamedObject>
{
  public Itest_Name Name { get; set; } = default!;

  internal static test_NamedDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DescribedDecoder : NullDecoder<Itest_DescribedObject>
{
  public ICollection<string> Description { get; set; } = default!;

  internal static test_DescribedDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ResolutionDecoder : NullDecoder<test_Resolution>
{
  public string Parallel { get; set; } = default!;
  public string Sequential { get; set; } = default!;
  public string Single { get; set; } = default!;

  internal static test_ResolutionDecoder Factory(IDecoderRepository _) => new();
}

internal class test_LocationDecoder : NullDecoder<test_Location>
{
  public string Operation { get; set; } = default!;
  public string Variable { get; set; } = default!;
  public string Field { get; set; } = default!;
  public string Inline { get; set; } = default!;
  public string Spread { get; set; } = default!;
  public string Fragment { get; set; } = default!;

  internal static test_LocationDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpDirectiveDecoder : NullDecoder<Itest_OpDirectiveObject>
{
  public Itest_OpArgument? Argument { get; set; } = default!;

  internal static test_OpDirectiveDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgumentDecoder : NullDecoder<Itest_OpArgumentObject>
{

  internal static test_OpArgumentDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgValueDecoder : NullDecoder<Itest_OpArgValueObject>
{
  public Itest_Name Variable { get; set; } = default!;

  internal static test_OpArgValueDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgListDecoder : NullDecoder<Itest_OpArgListObject>
{

  internal static test_OpArgListDecoder Factory(IDecoderRepository _) => new();
}

internal class test_OpArgMapDecoder : NullDecoder<Itest_OpArgMapObject>
{
  public Itest_OpArgValue Value { get; set; } = default!;
  public Itest_Name ByVariable { get; set; } = default!;

  internal static test_OpArgMapDecoder Factory(IDecoderRepository _) => new();
}

internal class test_PathDecoder : NullDecoder<Itest_Path>
{

  internal static test_PathDecoder Factory(IDecoderRepository _) => new();
}

internal class test_SimpleKindDecoder : NullDecoder<test_SimpleKind>
{
  public string Basic { get; set; } = default!;
  public string Enum { get; set; } = default!;
  public string Internal { get; set; } = default!;
  public string Domain { get; set; } = default!;
  public string Union { get; set; } = default!;

  internal static test_SimpleKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeKindDecoder : NullDecoder<test_TypeKind>
{
  public string Basic { get; set; } = default!;
  public string Enum { get; set; } = default!;
  public string Internal { get; set; } = default!;
  public string Domain { get; set; } = default!;
  public string Union { get; set; } = default!;
  public string Dual { get; set; } = default!;
  public string Input { get; set; } = default!;
  public string Output { get; set; } = default!;

  internal static test_TypeKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_TypeRefDecoder<TTypeKind>
{
  public TTypeKind TypeKind { get; set; } = default!;
}

internal class test_TypeSimpleDecoder : NullDecoder<Itest_TypeSimpleObject>
{

  internal static test_TypeSimpleDecoder Factory(IDecoderRepository _) => new();
}

internal class test_CollectionsDecoder : NullDecoder<Itest_CollectionsObject>
{

  internal static test_CollectionsDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierKeyedDecoder<TModifierKind>
{
  public Itest_TypeSimple By { get; set; } = default!;
  public bool IsOptional { get; set; } = default!;
}

internal class test_ModifiersDecoder : NullDecoder<Itest_ModifiersObject>
{

  internal static test_ModifiersDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierKindDecoder : NullDecoder<test_ModifierKind>
{
  public string Req { get; set; } = default!;
  public string Required { get; set; } = default!;
  public string Opt { get; set; } = default!;
  public string Optional { get; set; } = default!;
  public string List { get; set; } = default!;
  public string Dict { get; set; } = default!;
  public string Dictionary { get; set; } = default!;
  public string Param { get; set; } = default!;
  public string TypeParam { get; set; } = default!;

  internal static test_ModifierKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierDecoder<TModifierKind>
{
  public TModifierKind ModifierKind { get; set; } = default!;
}

internal class test_DomainKindDecoder : NullDecoder<test_DomainKind>
{
  public string Boolean { get; set; } = default!;
  public string Enum { get; set; } = default!;
  public string Number { get; set; } = default!;
  public string String { get; set; } = default!;

  internal static test_DomainKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_BaseDomainItemDecoder : NullDecoder<Itest_BaseDomainItemObject>
{
  public bool Exclude { get; set; } = default!;

  internal static test_BaseDomainItemDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainTrueFalseDecoder : NullDecoder<Itest_DomainTrueFalseObject>
{
  public bool Value { get; set; } = default!;

  internal static test_DomainTrueFalseDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainRangeDecoder : NullDecoder<Itest_DomainRangeObject>
{
  public decimal? Lower { get; set; } = default!;
  public decimal? Upper { get; set; } = default!;

  internal static test_DomainRangeDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainRegexDecoder : NullDecoder<Itest_DomainRegexObject>
{
  public string Pattern { get; set; } = default!;

  internal static test_DomainRegexDecoder Factory(IDecoderRepository _) => new();
}

internal class test_EnumLabelDecoder : NullDecoder<Itest_EnumLabelObject>
{
  public Itest_Name EnumType { get; set; } = default!;

  internal static test_EnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ObjectKindDecoder : NullDecoder<Itest_ObjectKind>
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
