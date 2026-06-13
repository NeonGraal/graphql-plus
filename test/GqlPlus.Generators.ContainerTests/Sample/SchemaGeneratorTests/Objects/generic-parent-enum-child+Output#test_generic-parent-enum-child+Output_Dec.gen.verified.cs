//HintName: test_generic-parent-enum-child+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Output;

internal class testEnumGnrcPrntEnumChildOutpDecoder : NullDecoder<testEnumGnrcPrntEnumChildOutp>
{
  public string gnrcPrntEnumChildOutpParent { get; set; } = default!;
  public string gnrcPrntEnumChildOutpLabel { get; set; } = default!;

  internal static testEnumGnrcPrntEnumChildOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildOutpDecoder : NullDecoder<testParentGnrcPrntEnumChildOutp>
{
  public string gnrcPrntEnumChildOutpParent { get; set; } = default!;

  internal static testParentGnrcPrntEnumChildOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_child_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_child_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumGnrcPrntEnumChildOutp>(testEnumGnrcPrntEnumChildOutpDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumChildOutp>(testParentGnrcPrntEnumChildOutpDecoder.Factory);
}
