//HintName: test_constraint-alt-dual+Input_Impl.gen.cs
// Generated from constraint-alt-dual+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

public class testCnstAltDualInp
  : ItestCnstAltDualInp
{
  public testRefCnstAltDualInp<testAltCnstAltDualInp> AsRefCnstAltDualInp { get; set; }
  public testCnstAltDualInp CnstAltDualInp { get; set; }
}

public class testRefCnstAltDualInp<Tref>
  : ItestRefCnstAltDualInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltDualInp RefCnstAltDualInp { get; set; }
}

public class testPrntCnstAltDualInp
  : ItestPrntCnstAltDualInp
{
  public testString AsString { get; set; }
  public testPrntCnstAltDualInp PrntCnstAltDualInp { get; set; }
}

public class testAltCnstAltDualInp
  : testPrntCnstAltDualInp
  , ItestAltCnstAltDualInp
{
  public testNumber alt { get; set; }
  public testAltCnstAltDualInp AltCnstAltDualInp { get; set; }
}
