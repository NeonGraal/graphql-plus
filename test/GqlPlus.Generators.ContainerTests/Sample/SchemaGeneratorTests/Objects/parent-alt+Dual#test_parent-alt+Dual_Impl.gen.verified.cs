//HintName: test_parent-alt+Dual_Impl.gen.cs
// Generated from parent-alt+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

public class testPrntAltDual
  : testRefPrntAltDual
  , ItestPrntAltDual
{
  public ItestNumber AsNumber { get; set; }
  public ItestPrntAltDualObject AsPrntAltDual { get; set; }
}

public class testRefPrntAltDual
  : ItestRefPrntAltDual
{
  public ItestNumber Parent { get; set; }
  public ItestString AsString { get; set; }
  public ItestRefPrntAltDualObject AsRefPrntAltDual { get; set; }
}
