//HintName: test_object-field-enum-alias+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Dual;

public class testObjFieldEnumAliasDual
  : GqlpEncoderBase
  , ItestObjFieldEnumAliasDual
{
  public ItestObjFieldEnumAliasDualObject? As_ObjFieldEnumAliasDual { get; set; }
}

public class testObjFieldEnumAliasDualObject
  : GqlpEncoderBase
  , ItestObjFieldEnumAliasDualObject
{
  public bool Field { get; set; }

  public testObjFieldEnumAliasDualObject
    ( bool field
    )
  {
    Field = field;
  }
}
