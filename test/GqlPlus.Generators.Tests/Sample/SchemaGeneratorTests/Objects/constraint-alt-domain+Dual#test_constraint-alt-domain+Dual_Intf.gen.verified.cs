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

public interface ItestCnstAltDmnDualField
{
}

public interface ItestRefCnstAltDmnDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltDmnDual RefCnstAltDmnDual { get; set; }
}

public interface ItestRefCnstAltDmnDualField<Tref>
{
}

public interface ItestDomCnstAltDmnDual
  : IDomainString
{
}
