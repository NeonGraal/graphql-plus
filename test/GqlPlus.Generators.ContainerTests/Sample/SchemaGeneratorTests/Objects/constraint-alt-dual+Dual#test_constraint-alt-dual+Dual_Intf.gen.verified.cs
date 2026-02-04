//HintName: test_constraint-alt-dual+Dual_Intf.gen.cs
// Generated from constraint-alt-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

public interface ItestCnstAltDualDual
{
  public testRefCnstAltDualDual<testAltCnstAltDualDual> AsRefCnstAltDualDual { get; set; }
  public testCnstAltDualDual CnstAltDualDual { get; set; }
}

public interface ItestCnstAltDualDualObject
{
}

public interface ItestRefCnstAltDualDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltDualDual RefCnstAltDualDual { get; set; }
}

public interface ItestRefCnstAltDualDualObject<Tref>
{
}

public interface ItestPrntCnstAltDualDual
{
  public testString AsString { get; set; }
  public testPrntCnstAltDualDual PrntCnstAltDualDual { get; set; }
}

public interface ItestPrntCnstAltDualDualObject
{
}

public interface ItestAltCnstAltDualDual
  : ItestPrntCnstAltDualDual
{
  public testAltCnstAltDualDual AltCnstAltDualDual { get; set; }
}

public interface ItestAltCnstAltDualDualObject
  : ItestPrntCnstAltDualDualObject
{
  public testNumber alt { get; set; }
}
