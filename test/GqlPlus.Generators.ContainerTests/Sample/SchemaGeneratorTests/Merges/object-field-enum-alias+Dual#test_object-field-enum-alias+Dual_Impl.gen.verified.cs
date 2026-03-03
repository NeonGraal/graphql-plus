//HintName: test_object-field-enum-alias+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Dual;

public class testObjFieldEnumAliasDual
  : GqlpModelImplementationBase
  , ItestObjFieldEnumAliasDual
{
  public ItestObjFieldEnumAliasDualObject? As_ObjFieldEnumAliasDual { get; set; }
}

public class testObjFieldEnumAliasDualObject
  : GqlpModelImplementationBase
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
