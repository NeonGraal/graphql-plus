//HintName: test_object-parent+Dual_Model.gen.cs
// Generated from {CurrentDirectory}object-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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

  public testObjPrntDualObject
    ()
  {
  }
}

public class testRefObjPrntDual
  : GqlpModelBase
  , ItestRefObjPrntDual
{
  public ItestRefObjPrntDualObject? As_RefObjPrntDual { get; set; }
}

public class testRefObjPrntDualObject
  : GqlpModelBase
  , ItestRefObjPrntDualObject
{

  public testRefObjPrntDualObject
    ()
  {
  }
}
