//HintName: test_object-field-type-alias+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Output;

public class testObjFieldTypeAliasOutp
  : GqlpModelBase
  , ItestObjFieldTypeAliasOutp
{
  public ItestObjFieldTypeAliasOutpObject? As_ObjFieldTypeAliasOutp { get; set; }
}

public class testObjFieldTypeAliasOutpObject
  : GqlpModelBase
  , ItestObjFieldTypeAliasOutpObject
{
  public string Field { get; set; }

  public testObjFieldTypeAliasOutpObject
    ( string field
    )
  {
    Field = field;
  }
}
