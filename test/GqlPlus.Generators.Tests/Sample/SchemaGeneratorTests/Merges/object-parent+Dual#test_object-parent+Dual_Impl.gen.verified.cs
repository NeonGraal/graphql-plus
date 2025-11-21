//HintName: test_object-parent+Dual_Impl.gen.cs
// Generated from object-parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Dual;

public class testObjPrntDual
  : testRefObjPrntDual
  , ItestObjPrntDual
{
  public testObjPrntDual ObjPrntDual { get; set; }
}

public class testRefObjPrntDual
  : ItestRefObjPrntDual
{
  public testRefObjPrntDual RefObjPrntDual { get; set; }
}
