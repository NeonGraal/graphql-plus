//HintName: test_constraint-alt-dual+Dual_Impl.gen.cs
// Generated from constraint-alt-dual+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

public class testCnstAltDualDual
  : ItestCnstAltDualDual
{
  public testRefCnstAltDualDual<testAltCnstAltDualDual> AsRefCnstAltDualDual { get; set; }
  public testCnstAltDualDual CnstAltDualDual { get; set; }
}

public class testRefCnstAltDualDual<Tref>
  : ItestRefCnstAltDualDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltDualDual RefCnstAltDualDual { get; set; }
}

public class testPrntCnstAltDualDual
  : ItestPrntCnstAltDualDual
{
  public testString AsString { get; set; }
  public testPrntCnstAltDualDual PrntCnstAltDualDual { get; set; }
}

public class testAltCnstAltDualDual
  : testPrntCnstAltDualDual
  , ItestAltCnstAltDualDual
{
  public testNumber alt { get; set; }
  public testAltCnstAltDualDual AltCnstAltDualDual { get; set; }
}
