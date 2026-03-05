//HintName: test_object-field-type-alias+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Input;

public class testObjFieldTypeAliasInp
  : GqlpModelImplementationBase
  , ItestObjFieldTypeAliasInp
{
  public ItestObjFieldTypeAliasInpObject? As_ObjFieldTypeAliasInp { get; set; }
}

public class testObjFieldTypeAliasInpObject
  : GqlpModelImplementationBase
  , ItestObjFieldTypeAliasInpObject
{
  public string Field { get; set; }

  public testObjFieldTypeAliasInpObject
    ( string field
    )
  {
    Field = field;
  }
}
