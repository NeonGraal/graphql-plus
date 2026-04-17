//HintName: test_generic-parent-enum-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Input;

internal class testGnrcPrntEnumPrntInpDecoder
{

  internal static testGnrcPrntEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumPrntInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntEnumPrntInpDecoder
{
  public string gnrcPrntEnumPrntInpParent { get; set; }
  public string gnrcPrntEnumPrntInpLabel { get; set; }

  internal static testEnumGnrcPrntEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntInpDecoder
{
  public string gnrcPrntEnumPrntInpParent { get; set; }

  internal static testParentGnrcPrntEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntEnumPrntInpObject>(testGnrcPrntEnumPrntInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumPrntInp>(testEnumGnrcPrntEnumPrntInpDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumPrntInp>(testParentGnrcPrntEnumPrntInpDecoder.Factory);
}
