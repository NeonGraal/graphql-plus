//HintName: test_object-field-type-alias+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Dual;

public class testObjFieldTypeAliasDual
  : GqlpModelImplementationBase
  , ItestObjFieldTypeAliasDual
{
  public ItestObjFieldTypeAliasDualObject? As_ObjFieldTypeAliasDual { get; set; }
}

public class testObjFieldTypeAliasDualObject
  : GqlpModelImplementationBase
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
