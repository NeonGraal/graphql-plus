//HintName: test_parent+Dual_Intf.gen.cs
// Generated from parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

public interface ItestPrntDual
  : ItestRefPrntDual
{
  ItestPrntDualObject AsPrntDual { get; }
}

public interface ItestPrntDualObject
  : ItestRefPrntDualObject
{
}

public interface ItestRefPrntDual
{
  string AsString { get; }
  ItestRefPrntDualObject AsRefPrntDual { get; }
}

public interface ItestRefPrntDualObject
{
  decimal Parent { get; }
}
