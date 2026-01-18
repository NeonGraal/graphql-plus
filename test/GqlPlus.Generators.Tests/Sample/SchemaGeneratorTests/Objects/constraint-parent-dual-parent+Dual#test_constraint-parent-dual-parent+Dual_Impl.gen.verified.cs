//HintName: test_constraint-parent-dual-parent+Dual_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Dual;

public class testCnstPrntDualPrntDual
  : testRefCnstPrntDualPrntDual
  , ItestCnstPrntDualPrntDual
{
  public testCnstPrntDualPrntDual CnstPrntDualPrntDual { get; set; }
}

public class testRefCnstPrntDualPrntDual<Tref>
  : testref
  , ItestRefCnstPrntDualPrntDual<Tref>
{
  public testRefCnstPrntDualPrntDual RefCnstPrntDualPrntDual { get; set; }
}

public class testPrntCnstPrntDualPrntDual
  : ItestPrntCnstPrntDualPrntDual
{
  public testString AsString { get; set; }
  public testPrntCnstPrntDualPrntDual PrntCnstPrntDualPrntDual { get; set; }
}

public class testAltCnstPrntDualPrntDual
  : testPrntCnstPrntDualPrntDual
  , ItestAltCnstPrntDualPrntDual
{
  public testNumber alt { get; set; }
  public testAltCnstPrntDualPrntDual AltCnstPrntDualPrntDual { get; set; }
}
