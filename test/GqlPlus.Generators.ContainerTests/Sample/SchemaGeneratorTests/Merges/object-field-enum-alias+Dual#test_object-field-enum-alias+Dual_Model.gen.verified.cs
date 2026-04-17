//HintName: test_object-field-enum-alias+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Dual;

public class testObjFieldEnumAliasDual
  : GqlpModelBase
  , ItestObjFieldEnumAliasDual
{
  public ItestObjFieldEnumAliasDualObject? As_ObjFieldEnumAliasDual { get; set; }
}

public class testObjFieldEnumAliasDualObject
  : GqlpModelBase
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
