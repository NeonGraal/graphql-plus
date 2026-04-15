//HintName: test_Built-In_Dec.gen.cs
// Generated from {CurrentDirectory}Built-In.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

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

internal static class test_Built_InDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_Built_InDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_CollectionsObject>(_ => new test_CollectionsDecoder())
      .AddDecoder<Itest_ModifiersObject>(_ => new test_ModifiersDecoder())
      .AddDecoder<test_ModifierKind>(_ => new test_ModifierKindDecoder());
}
