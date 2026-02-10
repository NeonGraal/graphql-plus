//HintName: test_parent-alt+Dual_Intf.gen.cs
// Generated from parent-alt+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

public interface ItestPrntAltDual
  : ItestRefPrntAltDual
{
  public decimal AsNumber { get; set; }
  public ItestPrntAltDualObject AsPrntAltDual { get; set; }
}

public interface ItestPrntAltDualObject
  : ItestRefPrntAltDualObject
{
}

public interface ItestRefPrntAltDual
{
  public string AsString { get; set; }
  public ItestRefPrntAltDualObject AsRefPrntAltDual { get; set; }
}

public interface ItestRefPrntAltDualObject
{
  public decimal Parent { get; set; }
}
