//HintName: test_generic-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

internal class testGnrcEnumInpDecoder
{

  internal static testGnrcEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcEnumInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumGnrcEnumInpDecoder : IDecoder<testEnumGnrcEnumInp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcEnumInp? output)
    => input.DecodeEnum("EnumGnrcEnumInp", out output);

  internal static testEnumGnrcEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcEnumInpObject>(testGnrcEnumInpDecoder.Factory)
      .AddDecoder<testEnumGnrcEnumInp?>(testEnumGnrcEnumInpDecoder.Factory);
}
