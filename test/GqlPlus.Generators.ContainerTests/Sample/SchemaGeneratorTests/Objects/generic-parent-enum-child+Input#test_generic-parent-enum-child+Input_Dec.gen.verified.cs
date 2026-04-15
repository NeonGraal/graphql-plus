//HintName: test_generic-parent-enum-child+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

internal class testGnrcPrntEnumChildInpDecoder
{
}

internal class testFieldGnrcPrntEnumChildInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntEnumChildInpDecoder
{
  public string gnrcPrntEnumChildInpParent { get; set; }
  public string gnrcPrntEnumChildInpLabel { get; set; }
}

internal class testParentGnrcPrntEnumChildInpDecoder
{
  public string gnrcPrntEnumChildInpParent { get; set; }
}

internal static class test_generic_parent_enum_child_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_child_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntEnumChildInpObject>(_ => new testGnrcPrntEnumChildInpDecoder())
      .AddDecoder<testEnumGnrcPrntEnumChildInp>(_ => new testEnumGnrcPrntEnumChildInpDecoder())
      .AddDecoder<testParentGnrcPrntEnumChildInp>(_ => new testParentGnrcPrntEnumChildInpDecoder());
}
