//HintName: test_generic-parent-dual-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

internal class testAltGnrcPrntDualPrntInpEncoder : IEncoder<ItestAltGnrcPrntDualPrntInpObject>
{
  public Structured Encode(ItestAltGnrcPrntDualPrntInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_dual_parent_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_dual_parent_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltGnrcPrntDualPrntInpObject>(testAltGnrcPrntDualPrntInpEncoder.Factory);
}
