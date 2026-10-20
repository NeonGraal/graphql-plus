//HintName: test_parent-field+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent-field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

internal class testPrntFieldDualDecoder : NullDecoder<ItestPrntFieldDualObject>
{
  public decimal Field { get; set; } = default!;

  internal static testPrntFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntFieldDualDecoder : NullDecoder<ItestRefPrntFieldDualObject>
{
  public decimal Parent { get; set; } = default!;

  internal static testRefPrntFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_parent_field_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_field_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntFieldDualObject>(testPrntFieldDualDecoder.Factory)
      .AddDecoder<ItestRefPrntFieldDualObject>(testRefPrntFieldDualDecoder.Factory);
}
