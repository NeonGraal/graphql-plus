//HintName: test_alt+Dual_Intf.gen.cs
// Generated from alt+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Dual;

public interface ItestAltDual
{
  ItestAltAltDual AsAltAltDual { get; }
  ItestAltDualObject AsAltDual { get; }
}

public interface ItestAltDualObject
{
}

public interface ItestAltAltDual
{
  string AsString { get; }
  ItestAltAltDualObject AsAltAltDual { get; }
}

public interface ItestAltAltDualObject
{
  decimal Alt { get; }
}
