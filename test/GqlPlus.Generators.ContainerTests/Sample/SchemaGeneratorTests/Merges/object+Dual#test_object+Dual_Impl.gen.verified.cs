//HintName: test_object+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}object+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_Dual;

public class testObjDual
  : GqlpModelImplementationBase
  , ItestObjDual
{
  public ItestObjDualObject? As_ObjDual { get; set; }
}

public class testObjDualObject
  : GqlpModelImplementationBase
  , ItestObjDualObject
{

  public testObjDualObject
    ()
  {
  }
}
