//HintName: test_object-field-enum-value+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Input;

public class testObjFieldEnumValueInp
  : GqlpModelBase
  , ItestObjFieldEnumValueInp
{
  public ItestObjFieldEnumValueInpObject? As_ObjFieldEnumValueInp { get; set; }
}

public class testObjFieldEnumValueInpObject
  : GqlpModelBase
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
