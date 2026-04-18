//HintName: test_object-field-type-alias+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Dual;

public class testObjFieldTypeAliasDual
  : GqlpModelBase
  , ItestObjFieldTypeAliasDual
{
  public ItestObjFieldTypeAliasDualObject? As_ObjFieldTypeAliasDual { get; set; }
}

public class testObjFieldTypeAliasDualObject
  : GqlpModelBase
  , ItestObjFieldTypeAliasDualObject
{
  public string Field { get; set; }

  public testObjFieldTypeAliasDualObject
    ( string field
    )
  {
    Field = field;
  }
}
