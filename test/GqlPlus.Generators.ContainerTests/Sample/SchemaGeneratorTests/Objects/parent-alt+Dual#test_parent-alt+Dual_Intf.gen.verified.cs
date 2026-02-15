//HintName: test_parent-alt+Dual_Intf.gen.cs
// Generated from parent-alt+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

public interface ItestPrntAltDual
  : ItestRefPrntAltDual
{
  decimal AsNumber { get; }
  ItestPrntAltDualObject AsPrntAltDual { get; }
}

public interface ItestPrntAltDualObject
  : ItestRefPrntAltDualObject
{
}

public interface ItestRefPrntAltDual
{
  string AsString { get; }
  ItestRefPrntAltDualObject AsRefPrntAltDual { get; }
}

public interface ItestRefPrntAltDualObject
{
  decimal Parent { get; }
}
