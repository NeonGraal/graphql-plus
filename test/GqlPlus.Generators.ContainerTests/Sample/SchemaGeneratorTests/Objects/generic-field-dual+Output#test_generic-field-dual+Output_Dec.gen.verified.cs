//HintName: test_generic-field-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

internal class testAltGnrcFieldDualOutpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcFieldDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_field_dual_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_field_dual_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltGnrcFieldDualOutpObject>(testAltGnrcFieldDualOutpDecoder.Factory);
}
