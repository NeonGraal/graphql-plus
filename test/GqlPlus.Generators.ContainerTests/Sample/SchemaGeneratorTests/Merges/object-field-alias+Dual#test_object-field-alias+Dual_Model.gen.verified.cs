//HintName: test_object-field-alias+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Dual;

public class testObjFieldAliasDual
  : GqlpModelBase
  , ItestObjFieldAliasDual
{
  public ItestObjFieldAliasDualObject? As_ObjFieldAliasDual { get; set; }
}

public class testObjFieldAliasDualObject
  : GqlpModelBase
  , ItestObjFieldAliasDualObject
{
  public ItestFldObjFieldAliasDual Field { get; set; }

  public testObjFieldAliasDualObject
    ( ItestFldObjFieldAliasDual pfield
    )
  {
    Field = pfield;
  }
}

public class testFldObjFieldAliasDual
  : GqlpModelBase
  , ItestFldObjFieldAliasDual
{
  public ItestFldObjFieldAliasDualObject? As_FldObjFieldAliasDual { get; set; }
}

public class testFldObjFieldAliasDualObject
  : GqlpModelBase
  , ItestFldObjFieldAliasDualObject
{

  public testFldObjFieldAliasDualObject
    ()
  {
  }
}
