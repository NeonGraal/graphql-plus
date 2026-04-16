//HintName: test_-Type_Dec.gen.cs
// Generated from {CurrentDirectory}-Type.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Type;

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
