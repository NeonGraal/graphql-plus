//HintName: test_generic-value+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

internal class testGnrcValueInpDecoder
{

  internal static testGnrcValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcValueInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumGnrcValueInpDecoder : IDecoder<testEnumGnrcValueInp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcValueInp? output)
    => input.DecodeEnum("EnumGnrcValueInp", out output);

  internal static testEnumGnrcValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_value_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_value_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcValueInpObject>(testGnrcValueInpDecoder.Factory)
      .AddDecoder<testEnumGnrcValueInp?>(testEnumGnrcValueInpDecoder.Factory);
}
