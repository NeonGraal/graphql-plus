//HintName: test_alt+Dual_Intf.gen.cs
// Generated from alt+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Dual;

public interface ItestAltDual
{
  public ItestAltAltDual AsAltAltDual { get; set; }
  public ItestAltDualObject AsAltDual { get; set; }
}

public interface ItestAltDualObject
{
}

public interface ItestAltAltDual
{
  public ItestString AsString { get; set; }
  public ItestAltAltDualObject AsAltAltDual { get; set; }
}

public interface ItestAltAltDualObject
{
  public ItestNumber Alt { get; set; }
}
