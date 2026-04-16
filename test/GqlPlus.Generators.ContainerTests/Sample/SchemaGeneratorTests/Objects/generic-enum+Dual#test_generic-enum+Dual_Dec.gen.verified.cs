//HintName: test_generic-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

internal class testGnrcEnumDualDecoder
{

  internal static testGnrcEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcEnumDualDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumGnrcEnumDualDecoder
{
  public string gnrcEnumDual { get; set; }

  internal static testEnumGnrcEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcEnumDualObject>(testGnrcEnumDualDecoder.Factory)
      .AddDecoder<testEnumGnrcEnumDual>(testEnumGnrcEnumDualDecoder.Factory);
}
