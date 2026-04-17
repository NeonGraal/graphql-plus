//HintName: test_generic-parent-simple-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Dual;

internal class testGnrcPrntSmplEnumDualDecoder
{

  internal static testGnrcPrntSmplEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntSmplEnumDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntSmplEnumDualDecoder
{
  public string gnrcPrntSmplEnumDual { get; set; }

  internal static testEnumGnrcPrntSmplEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_simple_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_simple_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntSmplEnumDualObject>(testGnrcPrntSmplEnumDualDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntSmplEnumDual>(testEnumGnrcPrntSmplEnumDualDecoder.Factory);
}
