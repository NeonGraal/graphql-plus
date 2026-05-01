//HintName: test_generic-descr+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Input;

internal class testGnrcDescrInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcDescrInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcDescrInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}
