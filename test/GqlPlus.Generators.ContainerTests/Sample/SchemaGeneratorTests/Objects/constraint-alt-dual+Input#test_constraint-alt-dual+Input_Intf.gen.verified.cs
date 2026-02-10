//HintName: test_constraint-alt-dual+Input_Intf.gen.cs
// Generated from constraint-alt-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

public interface ItestCnstAltDualInp
{
  public ItestRefCnstAltDualInp<ItestAltCnstAltDualInp> AsRefCnstAltDualInp { get; set; }
  public ItestCnstAltDualInpObject AsCnstAltDualInp { get; set; }
}

public interface ItestCnstAltDualInpObject
{
}

public interface ItestRefCnstAltDualInp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefCnstAltDualInpObject AsRefCnstAltDualInp { get; set; }
}

public interface ItestRefCnstAltDualInpObject<Tref>
{
}

public interface ItestPrntCnstAltDualInp
{
  public string AsString { get; set; }
  public ItestPrntCnstAltDualInpObject AsPrntCnstAltDualInp { get; set; }
}

public interface ItestPrntCnstAltDualInpObject
{
}

public interface ItestAltCnstAltDualInp
  : ItestPrntCnstAltDualInp
{
  public ItestAltCnstAltDualInpObject AsAltCnstAltDualInp { get; set; }
}

public interface ItestAltCnstAltDualInpObject
  : ItestPrntCnstAltDualInpObject
{
  public decimal Alt { get; set; }
}
