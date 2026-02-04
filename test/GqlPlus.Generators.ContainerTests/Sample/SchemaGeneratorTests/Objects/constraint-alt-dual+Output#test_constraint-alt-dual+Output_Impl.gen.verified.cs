//HintName: test_constraint-alt-dual+Output_Impl.gen.cs
// Generated from constraint-alt-dual+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public class testCnstAltDualOutp
  : ItestCnstAltDualOutp
{
  public testRefCnstAltDualOutp<testAltCnstAltDualOutp> AsRefCnstAltDualOutp { get; set; }
  public testCnstAltDualOutp CnstAltDualOutp { get; set; }
}

public class testRefCnstAltDualOutp<Tref>
  : ItestRefCnstAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltDualOutp RefCnstAltDualOutp { get; set; }
}

public class testPrntCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
  public testString AsString { get; set; }
  public testPrntCnstAltDualOutp PrntCnstAltDualOutp { get; set; }
}

public class testAltCnstAltDualOutp
  : testPrntCnstAltDualOutp
  , ItestAltCnstAltDualOutp
{
  public testNumber alt { get; set; }
  public testAltCnstAltDualOutp AltCnstAltDualOutp { get; set; }
}
