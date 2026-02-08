//HintName: test_parent-alt+Dual_Intf.gen.cs
// Generated from parent-alt+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

public interface ItestPrntAltDual
  : ItestRefPrntAltDual
{
  public ItestNumber AsNumber { get; set; }
}

public interface ItestPrntAltDualObject
  : ItestRefPrntAltDualObject
{
}

public interface ItestRefPrntAltDual
{
  public ItestString AsString { get; set; }
}

public interface ItestRefPrntAltDualObject
{
  public ItestNumber Parent { get; set; }
}
