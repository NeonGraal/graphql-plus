//HintName: test_object-field-type-alias+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Input;

public class testObjFieldTypeAliasInp
  : GqlpModelBase
  , ItestObjFieldTypeAliasInp
{
  public ItestObjFieldTypeAliasInpObject? As_ObjFieldTypeAliasInp { get; set; }
}

public class testObjFieldTypeAliasInpObject
  : GqlpModelBase
  , ItestObjFieldTypeAliasInpObject
{
  public string Field { get; set; }

  public testObjFieldTypeAliasInpObject
    ( string pfield
    )
  {
    Field = pfield;
  }
}
