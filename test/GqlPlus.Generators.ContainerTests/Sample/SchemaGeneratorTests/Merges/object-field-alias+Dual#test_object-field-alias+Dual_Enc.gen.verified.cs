//HintName: test_object-field-alias+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Dual;

internal class testObjFieldAliasDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasDualObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasDual> _itestFldObjFieldAliasDual = encoders.EncoderFor<ItestFldObjFieldAliasDual>();
  public Structured Encode(ItestObjFieldAliasDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasDual);
}

internal class testFldObjFieldAliasDualEncoder : IEncoder<ItestFldObjFieldAliasDualObject>
{
  public Structured Encode(ItestFldObjFieldAliasDualObject input)
    => Structured.Empty();
}
