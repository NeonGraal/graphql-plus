//HintName: test_object-field-enum-value+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Dual;

public class testObjFieldEnumValueDual
  : GqlpModelBase
  , ItestObjFieldEnumValueDual
{
  public ItestObjFieldEnumValueDualObject? As_ObjFieldEnumValueDual { get; set; }
}

public class testObjFieldEnumValueDualObject
  : GqlpModelBase
  , ItestObjFieldEnumValueDualObject
{
  public bool Field { get; set; }

  public testObjFieldEnumValueDualObject
    ( bool pfield
    )
  {
    Field = pfield;
  }
}
