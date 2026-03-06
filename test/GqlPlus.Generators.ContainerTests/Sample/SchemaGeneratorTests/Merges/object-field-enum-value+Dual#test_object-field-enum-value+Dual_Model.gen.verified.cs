//HintName: test_object-field-enum-value+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Dual;

public class testObjFieldEnumValueDual
  : GqlpModelImplementationBase
  , ItestObjFieldEnumValueDual
{
  public ItestObjFieldEnumValueDualObject? As_ObjFieldEnumValueDual { get; set; }
}

public class testObjFieldEnumValueDualObject
  : GqlpModelImplementationBase
  , ItestObjFieldEnumValueDualObject
{
  public bool Field { get; set; }

  public testObjFieldEnumValueDualObject
    ( bool field
    )
  {
    Field = field;
  }
}
