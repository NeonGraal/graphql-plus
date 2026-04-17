//HintName: test_field+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Dual;

internal class testFieldDualDecoder
{
  public string Field { get; set; }

  internal static testFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldDualObject>(testFieldDualDecoder.Factory);
}
