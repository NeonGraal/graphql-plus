//HintName: test_generic-alt-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

internal class testGnrcAltDualInpEncoder : IEncoder<ItestGnrcAltDualInpObject>
{
  public Structured Encode(ItestGnrcAltDualInpObject input)
    => Structured.Empty();

  internal static testGnrcAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltDualInpEncoder<TRef> : IEncoder<ItestRefGnrcAltDualInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltDualInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltDualInpEncoder : IEncoder<ItestAltGnrcAltDualInpObject>
{
  public Structured Encode(ItestAltGnrcAltDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_alt_dual_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_alt_dual_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcAltDualInpObject>(testGnrcAltDualInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltDualInpObject>(testAltGnrcAltDualInpEncoder.Factory);
}
