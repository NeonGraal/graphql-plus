//HintName: test_alt-descr+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_descr_Input;

internal class testAltDescrInpEncoder : IEncoder<ItestAltDescrInpObject>
{
  public Structured Encode(ItestAltDescrInpObject input)
    => Structured.Empty();

  internal static testAltDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_descr_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_descr_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltDescrInpObject>(testAltDescrInpEncoder.Factory);
}
