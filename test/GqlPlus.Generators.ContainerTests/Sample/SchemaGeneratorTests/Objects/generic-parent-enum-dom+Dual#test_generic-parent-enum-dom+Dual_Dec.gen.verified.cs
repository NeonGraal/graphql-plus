//HintName: test_generic-parent-enum-dom+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

internal class testGnrcPrntEnumDomDualDecoder
{
}

internal class testFieldGnrcPrntEnumDomDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntEnumDomDualDecoder
{
  public string gnrcPrntEnumDomDualLabel { get; set; }
  public string gnrcPrntEnumDomDualOther { get; set; }
}

internal class testDomGnrcPrntEnumDomDualDecoder
{
}

internal static class test_generic_parent_enum_dom_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_dom_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntEnumDomDualObject>(_ => new testGnrcPrntEnumDomDualDecoder())
      .AddDecoder<testEnumGnrcPrntEnumDomDual>(_ => new testEnumGnrcPrntEnumDomDualDecoder())
      .AddDecoder<ItestDomGnrcPrntEnumDomDual>(_ => new testDomGnrcPrntEnumDomDualDecoder());
}
