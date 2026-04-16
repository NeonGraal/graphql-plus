//HintName: test_constraint-alt-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

internal class testPrntCnstAltDualOutpDecoder
{

  internal static testPrntCnstAltDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_alt_dual_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_dual_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntCnstAltDualOutpObject>(testPrntCnstAltDualOutpDecoder.Factory);
}
