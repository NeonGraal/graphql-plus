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

internal class testEnumGnrcPrntEnumPrntDualDecoder : IDecoder<testEnumGnrcPrntEnumPrntDual?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntEnumPrntDual? output)
    => input.DecodeEnum("EnumGnrcPrntEnumPrntDual", out output);

  internal static testEnumGnrcPrntEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntDualDecoder : IDecoder<testParentGnrcPrntEnumPrntDual?>
{
  public IMessages Decoder(IValue input, out testParentGnrcPrntEnumPrntDual? output)
    => input.DecodeEnum("ParentGnrcPrntEnumPrntDual", out output);

  internal static testParentGnrcPrntEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_enum_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_enum_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntEnumPrntDualObject>(testGnrcPrntEnumPrntDualDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumPrntDual?>(testEnumGnrcPrntEnumPrntDualDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumPrntDual?>(testParentGnrcPrntEnumPrntDualDecoder.Factory);
}
