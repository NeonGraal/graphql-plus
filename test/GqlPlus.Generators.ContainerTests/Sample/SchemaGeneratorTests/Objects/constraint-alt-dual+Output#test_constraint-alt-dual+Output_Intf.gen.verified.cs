//HintName: test_constraint-alt-dual+Output_Intf.gen.cs
// Generated from constraint-alt-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public interface ItestCnstAltDualOutp
{
  public ItestRefCnstAltDualOutp<ItestAltCnstAltDualOutp> AsRefCnstAltDualOutp { get; set; }
  public ItestCnstAltDualOutpObject AsCnstAltDualOutp { get; set; }
}

public interface ItestCnstAltDualOutpObject
{
}

public interface ItestRefCnstAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefCnstAltDualOutpObject AsRefCnstAltDualOutp { get; set; }
}

public interface ItestRefCnstAltDualOutpObject<Tref>
{
}

public interface ItestPrntCnstAltDualOutp
{
  public string AsString { get; set; }
  public ItestPrntCnstAltDualOutpObject AsPrntCnstAltDualOutp { get; set; }
}

public interface ItestPrntCnstAltDualOutpObject
{
}

public interface ItestAltCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
  public ItestAltCnstAltDualOutpObject AsAltCnstAltDualOutp { get; set; }
}

public interface ItestAltCnstAltDualOutpObject
  : ItestPrntCnstAltDualOutpObject
{
  public decimal Alt { get; set; }
}
