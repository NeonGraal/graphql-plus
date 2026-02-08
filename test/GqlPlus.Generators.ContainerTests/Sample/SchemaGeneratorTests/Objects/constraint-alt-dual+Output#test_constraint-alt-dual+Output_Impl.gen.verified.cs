//HintName: test_constraint-alt-dual+Output_Impl.gen.cs
// Generated from constraint-alt-dual+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public class testCnstAltDualOutp
  : ItestCnstAltDualOutp
{
  public ItestRefCnstAltDualOutp<ItestAltCnstAltDualOutp> AsRefCnstAltDualOutp { get; set; }
  public ItestCnstAltDualOutpObject AsCnstAltDualOutp { get; set; }
}

public class testRefCnstAltDualOutp<Tref>
  : ItestRefCnstAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefCnstAltDualOutpObject AsRefCnstAltDualOutp { get; set; }
}

public class testPrntCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
  public ItestString AsString { get; set; }
  public ItestPrntCnstAltDualOutpObject AsPrntCnstAltDualOutp { get; set; }
}

public class testAltCnstAltDualOutp
  : testPrntCnstAltDualOutp
  , ItestAltCnstAltDualOutp
{
  public ItestNumber Alt { get; set; }
  public ItestAltCnstAltDualOutpObject AsAltCnstAltDualOutp { get; set; }
}
