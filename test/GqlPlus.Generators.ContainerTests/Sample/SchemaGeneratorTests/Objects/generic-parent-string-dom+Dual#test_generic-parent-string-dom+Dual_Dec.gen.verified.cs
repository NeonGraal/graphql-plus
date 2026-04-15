//HintName: test_generic-parent-string-dom+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Dual;

internal class testGnrcPrntStrDomDualDecoder
{
}

internal class testFieldGnrcPrntStrDomDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testDomGnrcPrntStrDomDualDecoder
{
}

internal static class test_generic_parent_string_dom_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_string_dom_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntStrDomDualObject>(_ => new testGnrcPrntStrDomDualDecoder())
      .AddDecoder<ItestDomGnrcPrntStrDomDual>(_ => new testDomGnrcPrntStrDomDualDecoder());
}
