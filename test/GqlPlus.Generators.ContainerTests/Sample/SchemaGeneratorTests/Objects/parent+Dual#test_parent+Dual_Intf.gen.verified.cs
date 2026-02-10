//HintName: test_parent+Dual_Intf.gen.cs
// Generated from parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

public interface ItestPrntDual
  : ItestRefPrntDual
{
  public ItestPrntDualObject AsPrntDual { get; set; }
}

public interface ItestPrntDualObject
  : ItestRefPrntDualObject
{
}

public interface ItestRefPrntDual
{
  public string AsString { get; set; }
  public ItestRefPrntDualObject AsRefPrntDual { get; set; }
}

public interface ItestRefPrntDualObject
{
  public decimal Parent { get; set; }
}
