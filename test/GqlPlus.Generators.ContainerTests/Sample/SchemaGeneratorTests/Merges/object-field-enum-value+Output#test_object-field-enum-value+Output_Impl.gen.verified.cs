//HintName: test_object-field-enum-value+Output_Impl.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Output;

public class testObjFieldEnumValueOutp
  : GqlpModelImplementationBase
  , ItestObjFieldEnumValueOutp
{
  public ItestObjFieldEnumValueOutpObject? As_ObjFieldEnumValueOutp { get; set; }
}

public class testObjFieldEnumValueOutpObject
  : GqlpModelImplementationBase
  , ItestObjFieldEnumValueOutpObject
{
  public bool Field { get; set; }

  public testObjFieldEnumValueOutpObject
    ( bool field
    )
  {
    Field = field;
  }
}
