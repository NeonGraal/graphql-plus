//HintName: test_generic-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

internal class testEnumGnrcEnumOutpDecoder : IDecoder<testEnumGnrcEnumOutp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcEnumOutp? output)
    => input.DecodeEnum("EnumGnrcEnumOutp", out output);

  internal static testEnumGnrcEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumGnrcEnumOutp?>(testEnumGnrcEnumOutpDecoder.Factory);
}
