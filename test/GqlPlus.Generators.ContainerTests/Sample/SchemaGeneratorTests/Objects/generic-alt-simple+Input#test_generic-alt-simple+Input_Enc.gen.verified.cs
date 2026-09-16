//HintName: test_generic-alt-simple+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

internal class testGnrcAltSmplInpEncoder : IEncoder<ItestGnrcAltSmplInpObject>
{
  public Structured Encode(ItestGnrcAltSmplInpObject input)
    => Structured.Empty();

  internal static testGnrcAltSmplInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltSmplInpEncoder<TRef> : IEncoder<ItestRefGnrcAltSmplInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltSmplInpObject<TRef> input)
    => Structured.Empty();
}

internal static class test_generic_alt_simple_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_alt_simple_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcAltSmplInpObject>(testGnrcAltSmplInpEncoder.Factory);
}
