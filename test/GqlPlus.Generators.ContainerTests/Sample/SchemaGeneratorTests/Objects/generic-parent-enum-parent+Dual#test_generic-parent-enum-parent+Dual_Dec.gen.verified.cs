//HintName: test_generic-parent-enum-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Dual;

internal class testGnrcPrntEnumPrntDualDecoder
{

  internal static testGnrcPrntEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumPrntDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntEnumPrntDualDecoder
{
  public string gnrcPrntEnumPrntDualParent { get; set; }
  public string gnrcPrntEnumPrntDualLabel { get; set; }

  internal static testEnumGnrcPrntEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntDualDecoder
{
  public string gnrcPrntEnumPrntDualParent { get; set; }

  internal static testParentGnrcPrntEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntEnumPrntDualObject>(testGnrcPrntEnumPrntDualDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumPrntDual>(testEnumGnrcPrntEnumPrntDualDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumPrntDual>(testParentGnrcPrntEnumPrntDualDecoder.Factory);
}
