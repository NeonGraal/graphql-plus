//HintName: test_object-field-enum-value+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Output;

public class testObjFieldEnumValueOutp
  : GqlpModelBase
  , ItestObjFieldEnumValueOutp
{
  public ItestObjFieldEnumValueOutpObject? As_ObjFieldEnumValueOutp { get; set; }
}

public class testObjFieldEnumValueOutpObject
  : GqlpModelBase
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
