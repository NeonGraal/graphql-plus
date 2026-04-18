//HintName: test_object-field-enum-alias+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Input;

public class testObjFieldEnumAliasInp
  : GqlpModelBase
  , ItestObjFieldEnumAliasInp
{
  public ItestObjFieldEnumAliasInpObject? As_ObjFieldEnumAliasInp { get; set; }
}

public class testObjFieldEnumAliasInpObject
  : GqlpModelBase
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
