//HintName: test_parent-alt+Dual_Impl.gen.cs
// Generated from parent-alt+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

public class testPrntAltDual
  : testRefPrntAltDual
  , ItestPrntAltDual
{
  public testNumber AsNumber { get; set; }
  public testPrntAltDual PrntAltDual { get; set; }
}

public class testRefPrntAltDual
  : ItestRefPrntAltDual
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testRefPrntAltDual RefPrntAltDual { get; set; }
}
