//HintName: test_object-field-alias+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Dual;

public class testObjFieldAliasDual
  : GqlpModelImplementationBase
  , ItestObjFieldAliasDual
{
  public ItestObjFieldAliasDualObject? As_ObjFieldAliasDual { get; set; }
}

public class testObjFieldAliasDualObject
  : GqlpModelImplementationBase
  , ItestObjFieldAliasDualObject
{
  public ItestFldObjFieldAliasDual Field { get; set; }

  public testObjFieldAliasDualObject
    ( ItestFldObjFieldAliasDual field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldAliasDual
  : GqlpModelImplementationBase
  , ItestFldObjFieldAliasDual
{
  public ItestFldObjFieldAliasDualObject? As_FldObjFieldAliasDual { get; set; }
}

public class testFldObjFieldAliasDualObject
  : GqlpModelImplementationBase
  , ItestFldObjFieldAliasDualObject
{
}
