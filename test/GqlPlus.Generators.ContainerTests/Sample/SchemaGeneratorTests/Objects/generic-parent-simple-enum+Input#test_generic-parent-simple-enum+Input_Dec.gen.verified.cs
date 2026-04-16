//HintName: test_generic-parent-simple-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Input;

internal class testGnrcPrntSmplEnumInpDecoder
{

  internal static testGnrcPrntSmplEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntSmplEnumInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntSmplEnumInpDecoder
{
  public string gnrcPrntSmplEnumInp { get; set; }

  internal static testEnumGnrcPrntSmplEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_simple_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_simple_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntSmplEnumInpObject>(testGnrcPrntSmplEnumInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntSmplEnumInp>(testEnumGnrcPrntSmplEnumInpDecoder.Factory);
}
