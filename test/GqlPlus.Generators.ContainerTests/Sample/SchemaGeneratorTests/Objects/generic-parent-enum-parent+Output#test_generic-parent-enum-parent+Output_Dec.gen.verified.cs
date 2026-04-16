//HintName: test_generic-parent-enum-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Output;

internal class testEnumGnrcPrntEnumPrntOutpDecoder
{
  public string gnrcPrntEnumPrntOutpParent { get; set; }
  public string gnrcPrntEnumPrntOutpLabel { get; set; }

  internal static testEnumGnrcPrntEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntOutpDecoder
{
  public string gnrcPrntEnumPrntOutpParent { get; set; }

  internal static testParentGnrcPrntEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_parent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_parent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumGnrcPrntEnumPrntOutp>(testEnumGnrcPrntEnumPrntOutpDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumPrntOutp>(testParentGnrcPrntEnumPrntOutpDecoder.Factory);
}
