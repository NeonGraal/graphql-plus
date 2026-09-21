//HintName: test_-Type_Dec.gen.cs
// Generated from {CurrentDirectory}-Type.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Type;

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

internal static class test__TypeDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__TypeDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_SimpleKind>(test_SimpleKindDecoder.Factory)
      .AddDecoder<test_TypeKind>(test_TypeKindDecoder.Factory)
      .AddDecoder<Itest_TypeSimpleObject>(test_TypeSimpleDecoder.Factory)
      .AddDecoder<Itest_CollectionsObject>(test_CollectionsDecoder.Factory)
      .AddDecoder<Itest_ModifiersObject>(test_ModifiersDecoder.Factory)
      .AddDecoder<test_ModifierKind>(test_ModifierKindDecoder.Factory);
}
