//HintName: test_object-constraint+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-constraint+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Output;

internal class testObjCnstOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjCnstOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjCnstOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type)
      .AddEncoded("str", input.Str, _type);
}
