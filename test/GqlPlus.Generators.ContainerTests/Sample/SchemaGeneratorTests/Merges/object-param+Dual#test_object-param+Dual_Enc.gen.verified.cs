//HintName: test_object-param+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Dual;

internal class testObjParamDualEncoder<TTest,TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamDualObject<TTest,TType>>
{
  private readonly IEncoder<TTest> _test = encoders.EncoderFor<TTest>();
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjParamDualObject<TTest,TType> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _type);
}
