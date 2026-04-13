//HintName: test_object-param-dup+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-param-dup+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Input;

internal class testObjParamDupInpEncoder<TTest>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamDupInpObject<TTest>>
{
  private readonly IEncoder<TTest> _test = encoders.EncoderFor<TTest>();
  public Structured Encode(ItestObjParamDupInpObject<TTest> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _test);
}
