//HintName: test_alt-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Output;

internal class testAltDualOutpEncoder : IEncoder<ItestAltDualOutpObject>
{
  public Structured Encode(ItestAltDualOutpObject input)
    => Structured.Empty();

  internal static testAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjDualAltDualOutpEncoder : IEncoder<ItestObjDualAltDualOutpObject>
{
  public Structured Encode(ItestObjDualAltDualOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testObjDualAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_dual_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_dual_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltDualOutpObject>(testAltDualOutpEncoder.Factory)
      .AddEncoder<ItestObjDualAltDualOutpObject>(testObjDualAltDualOutpEncoder.Factory);
}
