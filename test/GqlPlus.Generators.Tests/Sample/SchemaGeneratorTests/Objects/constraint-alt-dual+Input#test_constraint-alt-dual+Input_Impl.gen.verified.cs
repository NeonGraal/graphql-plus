//HintName: test_constraint-alt-dual+Input_Impl.gen.cs
// Generated from constraint-alt-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

public class testCnstAltDualInp
  : ItestCnstAltDualInp
{
  public RefCnstAltDualInp<AltCnstAltDualInp> AsRefCnstAltDualInp { get; set; }
}

public class testRefCnstAltDualInp<Tref>
  : ItestRefCnstAltDualInp<Tref>
{
  public Tref Asref { get; set; }
}

public class testPrntCnstAltDualInp
  : ItestPrntCnstAltDualInp
{
  public String AsString { get; set; }
}

public class testAltCnstAltDualInp
  : testPrntCnstAltDualInp
  , ItestAltCnstAltDualInp
{
  public Number alt { get; set; }
}
