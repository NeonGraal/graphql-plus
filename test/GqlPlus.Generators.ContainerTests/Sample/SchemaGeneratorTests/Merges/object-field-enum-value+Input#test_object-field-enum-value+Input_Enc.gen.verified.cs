//HintName: test_object-field-enum-value+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Input;

public class testObjFieldEnumValueInp
  : GqlpEncoderBase
  , ItestObjFieldEnumValueInp
{
  public ItestObjFieldEnumValueInpObject? As_ObjFieldEnumValueInp { get; set; }
}

public class testObjFieldEnumValueInpObject
  : GqlpEncoderBase
  , ItestObjFieldEnumValueInpObject
{
  public bool Field { get; set; }

  public testObjFieldEnumValueInpObject
    ( bool field
    )
  {
    Field = field;
  }
}
