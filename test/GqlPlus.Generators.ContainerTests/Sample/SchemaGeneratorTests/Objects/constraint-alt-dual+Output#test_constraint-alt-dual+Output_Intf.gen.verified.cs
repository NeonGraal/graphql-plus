//HintName: test_constraint-alt-dual+Output_Intf.gen.cs
// Generated from constraint-alt-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public interface ItestCnstAltDualOutp
{
  public ItestRefCnstAltDualOutp<ItestAltCnstAltDualOutp> AsRefCnstAltDualOutp { get; set; }
}

public interface ItestCnstAltDualOutpObject
{
}

public interface ItestRefCnstAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefCnstAltDualOutpObject<Tref>
{
}

public interface ItestPrntCnstAltDualOutp
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntCnstAltDualOutpObject
{
}

public interface ItestAltCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
}

public interface ItestAltCnstAltDualOutpObject
  : ItestPrntCnstAltDualOutpObject
{
  public ItestNumber Alt { get; set; }
}
