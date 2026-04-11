//HintName: test_object+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_Dual;

public class testObjDual
  : GqlpModelBase
  , ItestObjDual
{
  public ItestObjDualObject? As_ObjDual { get; set; }
}

public class testObjDualObject
  : GqlpModelBase
  , ItestObjDualObject
{

  public testObjDualObject
    ()
  {
  }
}
