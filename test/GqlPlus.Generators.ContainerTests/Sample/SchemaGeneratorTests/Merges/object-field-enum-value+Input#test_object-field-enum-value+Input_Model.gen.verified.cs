//HintName: test_object-field-enum-value+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Input;

public class testObjFieldEnumValueInp
  : GqlpModelImplementationBase
  , ItestObjFieldEnumValueInp
{
  public ItestObjFieldEnumValueInpObject? As_ObjFieldEnumValueInp { get; set; }
}

public class testObjFieldEnumValueInpObject
  : GqlpModelImplementationBase
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
