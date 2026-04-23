//HintName: test_alt+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Input;

internal class testAltInpEncoder : IEncoder<ItestAltInpObject>
{
  public Structured Encode(ItestAltInpObject input)
    => Structured.Empty();

  internal static testAltInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltInpEncoder : IEncoder<ItestAltAltInpObject>
{
  public Structured Encode(ItestAltAltInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltInpObject>(testAltInpEncoder.Factory)
      .AddEncoder<ItestAltAltInpObject>(testAltAltInpEncoder.Factory);
}
