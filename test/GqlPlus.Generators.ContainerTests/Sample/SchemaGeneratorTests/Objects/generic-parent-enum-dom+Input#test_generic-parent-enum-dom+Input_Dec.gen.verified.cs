//HintName: test_generic-parent-enum-dom+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Input;

internal class testGnrcPrntEnumDomInpDecoder
{

  internal static testGnrcPrntEnumDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumDomInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntEnumDomInpDecoder : IDecoder<testEnumGnrcPrntEnumDomInp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntEnumDomInp? output)
    => input.DecodeEnum("EnumGnrcPrntEnumDomInp", out output);

  internal static testEnumGnrcPrntEnumDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomInpDecoder
{

  internal static testDomGnrcPrntEnumDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_dom_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_dom_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntEnumDomInpObject>(testGnrcPrntEnumDomInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumDomInp?>(testEnumGnrcPrntEnumDomInpDecoder.Factory)
      .AddDecoder<ItestDomGnrcPrntEnumDomInp>(testDomGnrcPrntEnumDomInpDecoder.Factory);
}
