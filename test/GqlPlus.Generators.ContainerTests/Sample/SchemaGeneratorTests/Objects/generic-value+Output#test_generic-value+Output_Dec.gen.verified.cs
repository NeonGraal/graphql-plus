//HintName: test_generic-value+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

internal class testEnumGnrcValueOutpDecoder : IDecoder<testEnumGnrcValueOutp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcValueOutp? output)
    => input.DecodeEnum("EnumGnrcValueOutp", out output);

  internal static testEnumGnrcValueOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_value_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_value_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumGnrcValueOutp?>(testEnumGnrcValueOutpDecoder.Factory);
}
