//HintName: test_generic-parent-enum-dom+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Output;

internal class testEnumGnrcPrntEnumDomOutpDecoder : IDecoder<testEnumGnrcPrntEnumDomOutp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntEnumDomOutp? output)
    => input.DecodeEnum("EnumGnrcPrntEnumDomOutp", out output);

  internal static testEnumGnrcPrntEnumDomOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomOutpDecoder
{

  internal static testDomGnrcPrntEnumDomOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_dom_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_dom_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumGnrcPrntEnumDomOutp?>(testEnumGnrcPrntEnumDomOutpDecoder.Factory)
      .AddDecoder<ItestDomGnrcPrntEnumDomOutp>(testDomGnrcPrntEnumDomOutpDecoder.Factory);
}
