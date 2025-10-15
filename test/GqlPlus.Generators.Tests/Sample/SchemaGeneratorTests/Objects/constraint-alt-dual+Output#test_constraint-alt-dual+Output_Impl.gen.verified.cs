//HintName: test_constraint-alt-dual+Output_Impl.gen.cs
// Generated from constraint-alt-dual+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public class OutputtestCnstAltDualOutp
  : ItestCnstAltDualOutp
{
  public RefCnstAltDualOutp<AltCnstAltDualOutp> AsRefCnstAltDualOutp { get; set; }
}

public class OutputtestRefCnstAltDualOutp<Tref>
  : ItestRefCnstAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
}

public class DualtestPrntCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
  public String AsString { get; set; }
}

public class OutputtestAltCnstAltDualOutp
  : OutputtestPrntCnstAltDualOutp
  , ItestAltCnstAltDualOutp
{
  public Number alt { get; set; }
}
