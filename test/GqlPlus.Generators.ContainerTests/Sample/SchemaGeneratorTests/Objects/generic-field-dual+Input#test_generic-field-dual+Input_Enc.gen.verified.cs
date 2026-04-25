//HintName: test_generic-field-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

internal class testAltGnrcFieldDualInpEncoder : IEncoder<ItestAltGnrcFieldDualInpObject>
{
  public Structured Encode(ItestAltGnrcFieldDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_field_dual_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_field_dual_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltGnrcFieldDualInpObject>(testAltGnrcFieldDualInpEncoder.Factory);
}
