//HintName: test_constraint-alt-dual+Input_Intf.gen.cs
// Generated from constraint-alt-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

public interface ItestCnstAltDualInp
{
  public testRefCnstAltDualInp<testAltCnstAltDualInp> AsRefCnstAltDualInp { get; set; }
  public testCnstAltDualInp CnstAltDualInp { get; set; }
}

public interface ItestCnstAltDualInpObject
{
}

public interface ItestRefCnstAltDualInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltDualInp RefCnstAltDualInp { get; set; }
}

public interface ItestRefCnstAltDualInpObject<Tref>
{
}

public interface ItestPrntCnstAltDualInp
{
  public testString AsString { get; set; }
  public testPrntCnstAltDualInp PrntCnstAltDualInp { get; set; }
}

public interface ItestPrntCnstAltDualInpObject
{
}

public interface ItestAltCnstAltDualInp
  : ItestPrntCnstAltDualInp
{
  public testAltCnstAltDualInp AltCnstAltDualInp { get; set; }
}

public interface ItestAltCnstAltDualInpObject
  : ItestPrntCnstAltDualInpObject
{
  public testNumber alt { get; set; }
}
