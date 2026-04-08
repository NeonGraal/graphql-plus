//HintName: test_object-field-enum-alias+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Input;

public class testObjFieldEnumAliasInp
  : GqlpEncoderBase
  , ItestObjFieldEnumAliasInp
{
  public ItestObjFieldEnumAliasInpObject? As_ObjFieldEnumAliasInp { get; set; }
}

public class testObjFieldEnumAliasInpObject
  : GqlpEncoderBase
  , ItestObjFieldEnumAliasInpObject
{
  public bool Field { get; set; }

  public testObjFieldEnumAliasInpObject
    ( bool field
    )
  {
    Field = field;
  }
}
