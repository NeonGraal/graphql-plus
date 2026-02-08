//HintName: test_object-parent+Dual_Intf.gen.cs
// Generated from object-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Dual;

public interface ItestObjPrntDual
  : ItestRefObjPrntDual
{
  public ItestObjPrntDualObject AsObjPrntDual { get; set; }
}

public interface ItestObjPrntDualObject
  : ItestRefObjPrntDualObject
{
}

public interface ItestRefObjPrntDual
{
  public ItestRefObjPrntDualObject AsRefObjPrntDual { get; set; }
}

public interface ItestRefObjPrntDualObject
{
}
