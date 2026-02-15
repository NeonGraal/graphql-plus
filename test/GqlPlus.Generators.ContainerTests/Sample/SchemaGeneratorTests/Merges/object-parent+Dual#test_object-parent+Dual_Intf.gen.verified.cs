//HintName: test_object-parent+Dual_Intf.gen.cs
// Generated from object-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Dual;

public interface ItestObjPrntDual
  : ItestRefObjPrntDual
{
  ItestObjPrntDualObject AsObjPrntDual { get; }
}

public interface ItestObjPrntDualObject
  : ItestRefObjPrntDualObject
{
}

public interface ItestRefObjPrntDual
{
  ItestRefObjPrntDualObject AsRefObjPrntDual { get; }
}

public interface ItestRefObjPrntDualObject
{
}
