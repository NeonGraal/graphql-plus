//HintName: test_constraint-alt-dual+Output_Impl.gen.cs
// Generated from constraint-alt-dual+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public class testCnstAltDualOutp
  : ItestCnstAltDualOutp
{
}

public class testRefCnstAltDualOutp<TRef>
  : ItestRefCnstAltDualOutp<TRef>
{
}

public class testPrntCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
}

public class testAltCnstAltDualOutp
  : testPrntCnstAltDualOutp
  , ItestAltCnstAltDualOutp
{
  public decimal Alt { get; set; }
}
