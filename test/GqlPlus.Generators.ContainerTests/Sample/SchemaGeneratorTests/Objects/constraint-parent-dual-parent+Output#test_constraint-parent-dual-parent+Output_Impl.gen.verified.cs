//HintName: test_constraint-parent-dual-parent+Output_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Output;

public class testCnstPrntDualPrntOutp
  : testRefCnstPrntDualPrntOutp<ItestAltCnstPrntDualPrntOutp>
  , ItestCnstPrntDualPrntOutp
{
}

public class testRefCnstPrntDualPrntOutp<TRef>
  : ItestRefCnstPrntDualPrntOutp<TRef>
{
}

public class testPrntCnstPrntDualPrntOutp
  : ItestPrntCnstPrntDualPrntOutp
{
}

public class testAltCnstPrntDualPrntOutp
  : testPrntCnstPrntDualPrntOutp
  , ItestAltCnstPrntDualPrntOutp
{
  public decimal Alt { get; set; }
}
