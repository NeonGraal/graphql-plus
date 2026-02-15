//HintName: test_constraint-parent-dual-parent+Dual_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Dual;

public class testCnstPrntDualPrntDual
  : testRefCnstPrntDualPrntDual<ItestAltCnstPrntDualPrntDual>
  , ItestCnstPrntDualPrntDual
{
}

public class testRefCnstPrntDualPrntDual<TRef>
  : ItestRefCnstPrntDualPrntDual<TRef>
{
}

public class testPrntCnstPrntDualPrntDual
  : ItestPrntCnstPrntDualPrntDual
{
}

public class testAltCnstPrntDualPrntDual
  : testPrntCnstPrntDualPrntDual
  , ItestAltCnstPrntDualPrntDual
{
  public decimal Alt { get; set; }
}
