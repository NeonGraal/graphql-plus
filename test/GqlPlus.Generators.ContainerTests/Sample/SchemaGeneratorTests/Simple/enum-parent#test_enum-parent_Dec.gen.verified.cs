//HintName: test_enum-parent_Dec.gen.cs
// Generated from {CurrentDirectory}enum-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent;

internal class testEnumPrntDecoder : IDecoder<testEnumPrnt?>
{
  public IMessages Decoder(IValue input, out testEnumPrnt? output)
    => input.DecodeEnum("EnumPrnt", out output);

  internal static testEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDecoder : IDecoder<testPrntEnumPrnt?>
{
  public IMessages Decoder(IValue input, out testPrntEnumPrnt? output)
    => input.DecodeEnum("PrntEnumPrnt", out output);

  internal static testPrntEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumPrnt?>(testEnumPrntDecoder.Factory)
      .AddDecoder<testPrntEnumPrnt?>(testPrntEnumPrntDecoder.Factory);
}
