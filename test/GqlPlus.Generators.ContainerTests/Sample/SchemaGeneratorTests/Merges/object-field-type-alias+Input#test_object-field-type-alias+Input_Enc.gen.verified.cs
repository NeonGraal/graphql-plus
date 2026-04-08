//HintName: test_object-field-type-alias+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Input;

public class testObjFieldTypeAliasInp
  : GqlpEncoderBase
  , ItestObjFieldTypeAliasInp
{
  public ItestObjFieldTypeAliasInpObject? As_ObjFieldTypeAliasInp { get; set; }
}

public class testObjFieldTypeAliasInpObject
  : GqlpEncoderBase
  , ItestObjFieldTypeAliasInpObject
{
  public string Field { get; set; }

  public testObjFieldTypeAliasInpObject
    ( string field
    )
  {
    Field = field;
  }
}
