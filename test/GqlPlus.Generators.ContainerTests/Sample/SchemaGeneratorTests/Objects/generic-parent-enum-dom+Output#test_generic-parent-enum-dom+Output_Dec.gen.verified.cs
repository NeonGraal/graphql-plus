//HintName: test_generic-parent-enum-dom+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Output;

internal class testGnrcPrntEnumDomOutpDecoder
{
}

internal class testFieldGnrcPrntEnumDomOutpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntEnumDomOutpDecoder
{
  public string gnrcPrntEnumDomOutpLabel { get; set; }
  public string gnrcPrntEnumDomOutpOther { get; set; }
}

internal class testDomGnrcPrntEnumDomOutpDecoder
{
}

internal static class test_generic_parent_enum_dom_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_dom_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntEnumDomOutpObject>(_ => new testGnrcPrntEnumDomOutpDecoder())
      .AddDecoder<testEnumGnrcPrntEnumDomOutp>(_ => new testEnumGnrcPrntEnumDomOutpDecoder())
      .AddDecoder<ItestDomGnrcPrntEnumDomOutp>(_ => new testDomGnrcPrntEnumDomOutpDecoder());
}
