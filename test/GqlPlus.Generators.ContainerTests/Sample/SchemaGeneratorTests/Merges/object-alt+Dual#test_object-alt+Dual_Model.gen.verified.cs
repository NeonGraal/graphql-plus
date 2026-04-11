//HintName: test_object-alt+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Dual;

public class testObjAltDual
  : GqlpModelBase
  , ItestObjAltDual
{
  public ItestObjAltDualType? AsObjAltDualType { get; set; }
  public ItestObjAltDualObject? As_ObjAltDual { get; set; }
}

public class testObjAltDualObject
  : GqlpModelBase
  , ItestObjAltDualObject
{

  public testObjAltDualObject
    ()
  {
  }
}

public class testObjAltDualType
  : GqlpModelBase
  , ItestObjAltDualType
{
  public ItestObjAltDualTypeObject? As_ObjAltDualType { get; set; }
}

public class testObjAltDualTypeObject
  : GqlpModelBase
  , ItestObjAltDualTypeObject
{

  public testObjAltDualTypeObject
    ()
  {
  }
}
