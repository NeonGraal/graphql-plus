//HintName: test_constraint-parent-dual-parent+Input_Impl.gen.cs
// Generated from constraint-parent-dual-parent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

public class testCnstPrntDualPrntInp
  : testRefCnstPrntDualPrntInp<ItestAltCnstPrntDualPrntInp>
  , ItestCnstPrntDualPrntInp
{
}

public class testRefCnstPrntDualPrntInp<TRef>
  : ItestRefCnstPrntDualPrntInp<TRef>
{
}

public class testPrntCnstPrntDualPrntInp
  : ItestPrntCnstPrntDualPrntInp
{
}

public class testAltCnstPrntDualPrntInp
  : testPrntCnstPrntDualPrntInp
  , ItestAltCnstPrntDualPrntInp
{
  public decimal Alt { get; set; }
}
