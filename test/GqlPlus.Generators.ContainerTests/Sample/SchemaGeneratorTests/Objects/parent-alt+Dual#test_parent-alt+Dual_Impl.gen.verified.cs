//HintName: test_parent-alt+Dual_Impl.gen.cs
// Generated from parent-alt+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

public class testPrntAltDual
  : testRefPrntAltDual
  , ItestPrntAltDual
{
}

public class testRefPrntAltDual
  : ItestRefPrntAltDual
{
  public decimal Parent { get; set; }
}
