//HintName: test_object-field-enum-alias+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Output;

public class testObjFieldEnumAliasOutp
  : GqlpModelImplementationBase
  , ItestObjFieldEnumAliasOutp
{
  public ItestObjFieldEnumAliasOutpObject? As_ObjFieldEnumAliasOutp { get; set; }
}

public class testObjFieldEnumAliasOutpObject
  : GqlpModelImplementationBase
  , ItestObjFieldEnumAliasOutpObject
{
  public bool Field { get; set; }

  public testObjFieldEnumAliasOutpObject
    ( bool field
    )
  {
    Field = field;
  }
}
