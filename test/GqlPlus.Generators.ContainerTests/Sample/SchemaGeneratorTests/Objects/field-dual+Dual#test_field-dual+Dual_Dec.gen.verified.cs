//HintName: test_field-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Dual;

internal class testFieldDualDualDecoder
{
  public ItestFldFieldDualDual Field { get; set; }

  internal static testFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldFieldDualDualDecoder
{
  public decimal Field { get; set; }

  internal static testFldFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_dual_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_dual_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldDualDualObject>(testFieldDualDualDecoder.Factory)
      .AddDecoder<ItestFldFieldDualDualObject>(testFldFieldDualDualDecoder.Factory);
}
