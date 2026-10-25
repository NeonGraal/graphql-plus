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
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestGnrcDescrInpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}
