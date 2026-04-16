//HintName: test_alt-descr+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_descr_Output;

internal class testAltDescrOutpEncoder : IEncoder<ItestAltDescrOutpObject>
{
  public Structured Encode(ItestAltDescrOutpObject input)
    => Structured.Empty();

  internal static testAltDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_descr_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_descr_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltDescrOutpObject>(testAltDescrOutpEncoder.Factory);
}
