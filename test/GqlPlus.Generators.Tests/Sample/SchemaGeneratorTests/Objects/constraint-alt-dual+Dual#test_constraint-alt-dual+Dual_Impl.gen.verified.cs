//HintName: test_constraint-alt-dual+Dual_Impl.gen.cs
// Generated from constraint-alt-dual+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

public class testCnstAltDualDual
  : ItestCnstAltDualDual
{
  public RefCnstAltDualDual<AltCnstAltDualDual> AsRefCnstAltDualDual { get; set; }
}

public class testRefCnstAltDualDual<Tref>
  : ItestRefCnstAltDualDual<Tref>
{
  public Tref Asref { get; set; }
}

public class testPrntCnstAltDualDual
  : ItestPrntCnstAltDualDual
{
  public String AsString { get; set; }
}

public class testAltCnstAltDualDual
  : testPrntCnstAltDualDual
  , ItestAltCnstAltDualDual
{
  public Number alt { get; set; }
}
