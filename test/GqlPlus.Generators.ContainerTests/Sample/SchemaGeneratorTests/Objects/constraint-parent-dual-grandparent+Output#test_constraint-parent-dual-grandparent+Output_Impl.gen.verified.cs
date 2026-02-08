//HintName: test_constraint-parent-dual-grandparent+Output_Impl.gen.cs
// Generated from constraint-parent-dual-grandparent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

public class testCnstPrntDualGrndOutp
  : testRefCnstPrntDualGrndOutp
  , ItestCnstPrntDualGrndOutp
{
}

public class testRefCnstPrntDualGrndOutp<Tref>
  : testref
  , ItestRefCnstPrntDualGrndOutp<Tref>
{
}

public class testGrndCnstPrntDualGrndOutp
  : ItestGrndCnstPrntDualGrndOutp
{
  public ItestString AsString { get; set; }
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
  public ItestNumber Alt { get; set; }
}
