//HintName: test_constraint-alt-dual+Input_Impl.gen.cs
// Generated from constraint-alt-dual+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

public class testCnstAltDualInp
  : ItestCnstAltDualInp
{
}

public class testRefCnstAltDualInp<TRef>
  : ItestRefCnstAltDualInp<TRef>
{
}

public class testPrntCnstAltDualInp
  : ItestPrntCnstAltDualInp
{
}

public class testAltCnstAltDualInp
  : testPrntCnstAltDualInp
  , ItestAltCnstAltDualInp
{
  public decimal Alt { get; set; }
}
