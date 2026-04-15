//HintName: test_alt-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Output;

internal class testAltDualOutpEncoder : IEncoder<ItestAltDualOutpObject>
{
  public Structured Encode(ItestAltDualOutpObject input)
    => Structured.Empty();
}

internal class testObjDualAltDualOutpEncoder : IEncoder<ItestObjDualAltDualOutpObject>
{
  public Structured Encode(ItestObjDualAltDualOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal static class test_alt_dual_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_dual_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltDualOutpObject>(_ => new testAltDualOutpEncoder())
      .AddEncoder<ItestObjDualAltDualOutpObject>(_ => new testObjDualAltDualOutpEncoder());
}
