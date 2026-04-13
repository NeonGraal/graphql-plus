//HintName: test_object-field-alias+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Input;

internal class testObjFieldAliasInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasInpObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasInp> _itestFldObjFieldAliasInp = encoders.EncoderFor<ItestFldObjFieldAliasInp>();
  public Structured Encode(ItestObjFieldAliasInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasInp);
}

internal class testFldObjFieldAliasInpEncoder : IEncoder<ItestFldObjFieldAliasInpObject>
{
  public Structured Encode(ItestFldObjFieldAliasInpObject input)
    => Structured.Empty();
}
