//HintName: test_constraint-alt-domain+Dual_Intf.gen.cs
// Generated from constraint-alt-domain+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

public interface ItestCnstAltDmnDual
{
  public ItestRefCnstAltDmnDual<ItestDomCnstAltDmnDual> AsRefCnstAltDmnDual { get; set; }
  public ItestCnstAltDmnDualObject AsCnstAltDmnDual { get; set; }
}

public interface ItestCnstAltDmnDualObject
{
}

public interface ItestRefCnstAltDmnDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefCnstAltDmnDualObject AsRefCnstAltDmnDual { get; set; }
}

public interface ItestRefCnstAltDmnDualObject<Tref>
{
}

public interface ItestDomCnstAltDmnDual
  : IDomainString
{
}
