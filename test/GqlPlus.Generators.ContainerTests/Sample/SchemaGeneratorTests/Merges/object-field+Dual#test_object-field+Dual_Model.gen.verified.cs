//HintName: test_object-field+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Dual;

public class testObjFieldDual
  : GqlpModelImplementationBase
  , ItestObjFieldDual
{
  public ItestObjFieldDualObject? As_ObjFieldDual { get; set; }
}

public class testObjFieldDualObject
  : GqlpModelImplementationBase
  , ItestObjFieldDualObject
{
  public ItestFldObjFieldDual Field { get; set; }

  public testObjFieldDualObject
    ( ItestFldObjFieldDual field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldDual
  : GqlpModelImplementationBase
  , ItestFldObjFieldDual
{
  public ItestFldObjFieldDualObject? As_FldObjFieldDual { get; set; }
}

public class testFldObjFieldDualObject
  : GqlpModelImplementationBase
  , ItestFldObjFieldDualObject
{
}
