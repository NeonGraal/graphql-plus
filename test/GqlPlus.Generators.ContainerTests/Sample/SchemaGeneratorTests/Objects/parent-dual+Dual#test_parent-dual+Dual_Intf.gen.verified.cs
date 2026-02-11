//HintName: test_parent-dual+Dual_Intf.gen.cs
// Generated from parent-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Dual;

public interface ItestPrntDualDual
  : ItestRefPrntDualDual
{
  ItestPrntDualDualObject AsPrntDualDual { get; }
}

public interface ItestPrntDualDualObject
  : ItestRefPrntDualDualObject
{
}

public interface ItestRefPrntDualDual
{
  string AsString { get; }
  ItestRefPrntDualDualObject AsRefPrntDualDual { get; }
}

public interface ItestRefPrntDualDualObject
{
  decimal Parent { get; }
}
