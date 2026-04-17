//HintName: test_alt+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Output;

internal class testAltOutpEncoder : IEncoder<ItestAltOutpObject>
{
  public Structured Encode(ItestAltOutpObject input)
    => Structured.Empty();

  internal static testAltOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltOutpEncoder : IEncoder<ItestAltAltOutpObject>
{
  public Structured Encode(ItestAltAltOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

  internal static testAltAltOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltOutpObject>(testAltOutpEncoder.Factory)
      .AddEncoder<ItestAltAltOutpObject>(testAltAltOutpEncoder.Factory);
}
