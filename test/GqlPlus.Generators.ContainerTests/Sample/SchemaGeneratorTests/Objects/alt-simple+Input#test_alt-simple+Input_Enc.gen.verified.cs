//HintName: test_alt-simple+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_simple_Input;

internal class testAltSmplInpEncoder : IEncoder<ItestAltSmplInpObject>
{
  public Structured Encode(ItestAltSmplInpObject input)
    => Structured.Empty();

  internal static testAltSmplInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_simple_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_simple_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltSmplInpObject>(testAltSmplInpEncoder.Factory);
}
