//HintName: test_alt+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Output;

internal class testAltOutpEncoder : IEncoder<ItestAltOutpObject>
{
  public Structured Encode(ItestAltOutpObject input)
    => Structured.Empty();
}

internal class testAltAltOutpEncoder : IEncoder<ItestAltAltOutpObject>
{
  public Structured Encode(ItestAltAltOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal static class test_alt_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltOutpObject>(_ => new testAltOutpEncoder())
      .AddEncoder<ItestAltAltOutpObject>(_ => new testAltAltOutpEncoder());
}
