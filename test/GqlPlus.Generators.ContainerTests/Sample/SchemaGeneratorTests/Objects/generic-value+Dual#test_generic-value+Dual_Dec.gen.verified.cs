//HintName: test_generic-value+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

internal class testGnrcValueDualDecoder
{

  internal static testGnrcValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcValueDualDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumGnrcValueDualDecoder
{
  public string gnrcValueDual { get; set; }

  internal static testEnumGnrcValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_value_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_value_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcValueDualObject>(testGnrcValueDualDecoder.Factory)
      .AddDecoder<testEnumGnrcValueDual>(testEnumGnrcValueDualDecoder.Factory);
}
