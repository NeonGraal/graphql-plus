//HintName: test_object-field-enum-alias+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Output;

public class testObjFieldEnumAliasOutp
  : GqlpModelBase
  , ItestObjFieldEnumAliasOutp
{
  public ItestObjFieldEnumAliasOutpObject? As_ObjFieldEnumAliasOutp { get; set; }
}

public class testObjFieldEnumAliasOutpObject
  : GqlpModelBase
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
