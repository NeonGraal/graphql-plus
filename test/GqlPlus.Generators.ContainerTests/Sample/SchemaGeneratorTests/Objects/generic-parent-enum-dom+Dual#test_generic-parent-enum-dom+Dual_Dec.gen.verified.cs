//HintName: test_generic-parent-enum-dom+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

internal class testGnrcPrntEnumDomDualDecoder : NullDecoder<ItestGnrcPrntEnumDomDualObject>
{

  internal static testGnrcPrntEnumDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumDomDualDecoder<TRef>
{
  public TRef Field { get; set; } = default!;
}

internal class testEnumGnrcPrntEnumDomDualDecoder : NullDecoder<testEnumGnrcPrntEnumDomDual>
{
  public string gnrcPrntEnumDomDualLabel { get; set; } = default!;
  public string gnrcPrntEnumDomDualOther { get; set; } = default!;

  internal static testEnumGnrcPrntEnumDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomDualDecoder : NullDecoder<ItestDomGnrcPrntEnumDomDual>
{

  internal static testDomGnrcPrntEnumDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_dom_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_dom_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntEnumDomDualObject>(testGnrcPrntEnumDomDualDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumDomDual>(testEnumGnrcPrntEnumDomDualDecoder.Factory)
      .AddDecoder<ItestDomGnrcPrntEnumDomDual>(testDomGnrcPrntEnumDomDualDecoder.Factory);
}
