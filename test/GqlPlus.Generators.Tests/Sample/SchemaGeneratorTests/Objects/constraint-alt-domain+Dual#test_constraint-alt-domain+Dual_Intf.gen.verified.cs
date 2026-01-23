//HintName: test_constraint-alt-domain+Dual_Intf.gen.cs
// Generated from constraint-alt-domain+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

public interface ItestCnstAltDmnDual
{
  public testRefCnstAltDmnDual<testDomCnstAltDmnDual> AsRefCnstAltDmnDual { get; set; }
  public testCnstAltDmnDual CnstAltDmnDual { get; set; }
}

public interface ItestCnstAltDmnDualObject
{
}

public interface ItestRefCnstAltDmnDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltDmnDual RefCnstAltDmnDual { get; set; }
}

public interface ItestRefCnstAltDmnDualObject<Tref>
{
}

public interface ItestDomCnstAltDmnDual
  : IDomainString
{
}
