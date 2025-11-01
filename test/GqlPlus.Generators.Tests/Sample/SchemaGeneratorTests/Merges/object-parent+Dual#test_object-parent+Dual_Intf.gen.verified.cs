//HintName: test_object-parent+Dual_Intf.gen.cs
// Generated from object-parent+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Dual;

public interface ItestObjPrntDual
  : ItestRefObjPrntDual
{
  public testObjPrntDual ObjPrntDual { get; set; }
}

public interface ItestObjPrntDualField
  : ItestRefObjPrntDualField
{
}

public interface ItestRefObjPrntDual
{
  public testRefObjPrntDual RefObjPrntDual { get; set; }
}

public interface ItestRefObjPrntDualField
{
}
