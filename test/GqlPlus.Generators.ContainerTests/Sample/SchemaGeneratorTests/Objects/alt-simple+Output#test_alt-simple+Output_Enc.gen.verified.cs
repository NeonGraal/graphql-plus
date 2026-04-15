//HintName: test_alt-simple+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt-simple+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_simple_Output;

internal class testAltSmplOutpEncoder : IEncoder<ItestAltSmplOutpObject>
{
  public Structured Encode(ItestAltSmplOutpObject input)
    => Structured.Empty();

  internal static testAltSmplOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_simple_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_simple_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltSmplOutpObject>(testAltSmplOutpEncoder.Factory);
}
