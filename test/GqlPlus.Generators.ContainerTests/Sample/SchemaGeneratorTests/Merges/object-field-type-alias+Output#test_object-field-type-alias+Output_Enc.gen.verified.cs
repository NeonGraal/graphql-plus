//HintName: test_object-field-type-alias+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Output;

internal class testObjFieldTypeAliasOutpEncoder : IEncoder<ItestObjFieldTypeAliasOutpObject>
{
  public Structured Encode(ItestObjFieldTypeAliasOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}
