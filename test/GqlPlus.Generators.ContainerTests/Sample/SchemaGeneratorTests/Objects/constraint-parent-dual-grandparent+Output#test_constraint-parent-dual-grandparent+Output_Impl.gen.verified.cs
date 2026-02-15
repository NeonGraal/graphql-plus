//HintName: test_constraint-parent-dual-grandparent+Output_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

public class testCnstPrntDualGrndOutp
  : testRefCnstPrntDualGrndOutp<ItestAltCnstPrntDualGrndOutp>
  , ItestCnstPrntDualGrndOutp
{
}

public class testRefCnstPrntDualGrndOutp<TRef>
  : ItestRefCnstPrntDualGrndOutp<TRef>
{
}

public class testGrndCnstPrntDualGrndOutp
  : ItestGrndCnstPrntDualGrndOutp
{
}

public class testPrntCnstPrntDualGrndOutp
  : testGrndCnstPrntDualGrndOutp
  , ItestPrntCnstPrntDualGrndOutp
{
}

public class testAltCnstPrntDualGrndOutp
  : testPrntCnstPrntDualGrndOutp
  , ItestAltCnstPrntDualGrndOutp
{
  public decimal Alt { get; set; }
}
