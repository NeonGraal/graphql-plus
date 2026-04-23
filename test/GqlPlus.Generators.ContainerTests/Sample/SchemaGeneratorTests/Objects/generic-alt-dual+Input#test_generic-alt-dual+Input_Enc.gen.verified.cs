//HintName: test_generic-alt-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

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
      .AddEncoder<ItestAltGnrcAltDualInpObject>(testAltGnrcAltDualInpEncoder.Factory);
}
