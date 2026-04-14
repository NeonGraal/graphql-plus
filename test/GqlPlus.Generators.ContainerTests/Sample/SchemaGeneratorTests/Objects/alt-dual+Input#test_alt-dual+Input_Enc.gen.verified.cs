//HintName: test_alt-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Input;

internal class testObjDualAltDualInpEncoder : IEncoder<ItestObjDualAltDualInpObject>
{
  public Structured Encode(ItestObjDualAltDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal static class test_alt_dual_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_dual_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjDualAltDualInpObject>(_ => new testObjDualAltDualInpEncoder());
}
