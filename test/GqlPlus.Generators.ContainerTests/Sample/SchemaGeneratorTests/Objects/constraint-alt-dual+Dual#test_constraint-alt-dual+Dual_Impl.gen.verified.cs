//HintName: test_constraint-alt-dual+Dual_Impl.gen.cs
// Generated from constraint-alt-dual+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

public class testCnstAltDualDual
  : ItestCnstAltDualDual
{
}

public class testRefCnstAltDualDual<TRef>
  : ItestRefCnstAltDualDual<TRef>
{
}

public class testPrntCnstAltDualDual
  : ItestPrntCnstAltDualDual
{
}

public class testAltCnstAltDualDual
  : testPrntCnstAltDualDual
  , ItestAltCnstAltDualDual
{
  public decimal Alt { get; set; }
}
