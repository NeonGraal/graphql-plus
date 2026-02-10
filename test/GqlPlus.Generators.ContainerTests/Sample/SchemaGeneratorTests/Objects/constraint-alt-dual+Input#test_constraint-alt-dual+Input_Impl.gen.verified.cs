//HintName: test_constraint-alt-dual+Input_Impl.gen.cs
// Generated from constraint-alt-dual+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

public class testCnstAltDualInp
  : ItestCnstAltDualInp
{
  public ItestRefCnstAltDualInp<ItestAltCnstAltDualInp> AsRefCnstAltDualInp { get; set; }
  public ItestCnstAltDualInpObject AsCnstAltDualInp { get; set; }
}

public class testRefCnstAltDualInp<Tref>
  : ItestRefCnstAltDualInp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefCnstAltDualInpObject AsRefCnstAltDualInp { get; set; }
}

public class testPrntCnstAltDualInp
  : ItestPrntCnstAltDualInp
{
  public string AsString { get; set; }
  public ItestPrntCnstAltDualInpObject AsPrntCnstAltDualInp { get; set; }
}

public class testAltCnstAltDualInp
  : testPrntCnstAltDualInp
  , ItestAltCnstAltDualInp
{
  public decimal Alt { get; set; }
  public ItestAltCnstAltDualInpObject AsAltCnstAltDualInp { get; set; }
}
