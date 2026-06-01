//HintName: test_Full_Dec.gen.cs
// Generated from {CurrentDirectory}Full.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Full;

internal class test_RequestDecoder : NullDecoder<Itest_RequestObject>
{
  public Itest_Identifier? Category { get; set; } = default!;
  public Itest_Identifier? Operation { get; set; } = default!;
  public Itest_Operation Definition { get; set; } = default!;
  public object? Parameters { get; set; } = default!;

  internal static test_RequestDecoder Factory(IDecoderRepository _) => new();
}

internal class test_IdentifierDecoder : NullDecoder<Itest_Identifier>
{

  internal static test_IdentifierDecoder Factory(IDecoderRepository _) => new();
}

internal class test_CollectionsDecoder : NullDecoder<Itest_CollectionsObject>
{

  internal static test_CollectionsDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierKeyedDecoder<TModifierKind>
{
  public Itest_Identifier By { get; set; } = default!;
  public bool IsOptional { get; set; } = default!;
}

internal class test_ModifiersDecoder : NullDecoder<Itest_ModifiersObject>
{

  internal static test_ModifiersDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ModifierKindDecoder : NullDecoder<test_ModifierKind>
{
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

internal static class test_FullDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_FullDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_RequestObject>(test_RequestDecoder.Factory)
      .AddDecoder<Itest_Identifier>(test_IdentifierDecoder.Factory)
      .AddDecoder<Itest_CollectionsObject>(test_CollectionsDecoder.Factory)
      .AddDecoder<Itest_ModifiersObject>(test_ModifiersDecoder.Factory)
      .AddDecoder<test_ModifierKind>(test_ModifierKindDecoder.Factory);
}
