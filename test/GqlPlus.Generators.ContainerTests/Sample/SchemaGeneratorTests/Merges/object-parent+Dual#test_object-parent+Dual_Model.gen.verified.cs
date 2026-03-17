//HintName: test_object-parent+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Dual;

public class testObjPrntDual
  : testRefObjPrntDual
  , ItestObjPrntDual
{
  public ItestObjPrntDualObject? As_ObjPrntDual { get; set; }
}

public class testObjPrntDualObject
  : testRefObjPrntDualObject
  , ItestObjPrntDualObject
{
}

public class testRefObjPrntDual
  : GqlpModelImplementationBase
  , ItestRefObjPrntDual
{
  public ItestRefObjPrntDualObject? As_RefObjPrntDual { get; set; }
}

public class testRefObjPrntDualObject
  : GqlpModelImplementationBase
  , ItestRefObjPrntDualObject
{
}
