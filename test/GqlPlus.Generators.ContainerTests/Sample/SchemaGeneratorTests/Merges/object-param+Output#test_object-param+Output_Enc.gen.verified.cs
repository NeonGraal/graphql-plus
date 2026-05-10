//HintName: test_object-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Output;

internal class testObjParamOutpEncoder<TTest,TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamOutpObject<TTest,TType>>
{
  private readonly DeferOne<IEncoder<TTest>> _test = encoders.EncoderFor<TTest>();
  private readonly DeferOne<IEncoder<TType>> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjParamOutpObject<TTest,TType> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test.I)
      .AddEncoded("type", input.Type, _type.I);
}
