//HintName: test_constraint-field-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

internal class testPrntCnstFieldDualOutpDecoder
{

  internal static testPrntCnstFieldDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_field_dual_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_dual_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntCnstFieldDualOutpObject>(testPrntCnstFieldDualOutpDecoder.Factory);
}
