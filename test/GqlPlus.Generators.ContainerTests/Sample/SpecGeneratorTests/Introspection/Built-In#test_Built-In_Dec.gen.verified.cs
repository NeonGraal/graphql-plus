//HintName: test_Built-In_Dec.gen.cs
// Generated from {CurrentDirectory}Built-In.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

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

internal static class test_Built_InDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_Built_InDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_CollectionsObject>(test_CollectionsDecoder.Factory)
      .AddDecoder<Itest_ModifiersObject>(test_ModifiersDecoder.Factory)
      .AddDecoder<test_ModifierKind>(test_ModifierKindDecoder.Factory);
}
