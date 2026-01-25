//HintName: test_constraint-alt-dual+Output_Intf.gen.cs
// Generated from constraint-alt-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public interface ItestCnstAltDualOutp
{
  public testRefCnstAltDualOutp<testAltCnstAltDualOutp> AsRefCnstAltDualOutp { get; set; }
  public testCnstAltDualOutp CnstAltDualOutp { get; set; }
}

public interface ItestCnstAltDualOutpObject
{
}

public interface ItestRefCnstAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltDualOutp RefCnstAltDualOutp { get; set; }
}

public interface ItestRefCnstAltDualOutpObject<Tref>
{
}

public interface ItestPrntCnstAltDualOutp
{
  public testString AsString { get; set; }
  public testPrntCnstAltDualOutp PrntCnstAltDualOutp { get; set; }
}

public interface ItestPrntCnstAltDualOutpObject
{
}

public interface ItestAltCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
  public testAltCnstAltDualOutp AltCnstAltDualOutp { get; set; }
}

public interface ItestAltCnstAltDualOutpObject
  : ItestPrntCnstAltDualOutpObject
{
  public testNumber alt { get; set; }
}
