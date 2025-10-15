//HintName: test_constraint-alt-dual+Input_Impl.gen.cs
// Generated from constraint-alt-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

public class InputtestCnstAltDualInp
  : ItestCnstAltDualInp
{
  public RefCnstAltDualInp<AltCnstAltDualInp> AsRefCnstAltDualInp { get; set; }
}

public class InputtestRefCnstAltDualInp<Tref>
  : ItestRefCnstAltDualInp<Tref>
{
  public Tref Asref { get; set; }
}

public class DualtestPrntCnstAltDualInp
  : ItestPrntCnstAltDualInp
{
  public String AsString { get; set; }
}

public class InputtestAltCnstAltDualInp
  : InputtestPrntCnstAltDualInp
  , ItestAltCnstAltDualInp
{
  public Number alt { get; set; }
}
