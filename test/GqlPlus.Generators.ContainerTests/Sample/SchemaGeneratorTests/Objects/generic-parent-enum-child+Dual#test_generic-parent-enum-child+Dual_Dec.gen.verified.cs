//HintName: test_generic-parent-enum-child+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Dual;

internal class testGnrcPrntEnumChildDualDecoder : NullDecoder<ItestGnrcPrntEnumChildDualObject>
{

  internal static testGnrcPrntEnumChildDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumChildDualDecoder<TRef>
{
  public TRef Field { get; set; } = default!;
}

internal class testEnumGnrcPrntEnumChildDualDecoder : NullDecoder<testEnumGnrcPrntEnumChildDual>
{
  public string gnrcPrntEnumChildDualParent { get; set; } = default!;
  public string gnrcPrntEnumChildDualLabel { get; set; } = default!;

  internal static testEnumGnrcPrntEnumChildDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildDualDecoder : NullDecoder<testParentGnrcPrntEnumChildDual>
{
  public string gnrcPrntEnumChildDualParent { get; set; } = default!;

  internal static testParentGnrcPrntEnumChildDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_child_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_child_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntEnumChildDualObject>(testGnrcPrntEnumChildDualDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumChildDual>(testEnumGnrcPrntEnumChildDualDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumChildDual>(testParentGnrcPrntEnumChildDualDecoder.Factory);
}
