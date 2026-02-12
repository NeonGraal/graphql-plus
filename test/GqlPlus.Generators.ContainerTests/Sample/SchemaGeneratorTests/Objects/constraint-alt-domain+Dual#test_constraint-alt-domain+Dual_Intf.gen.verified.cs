//HintName: test_constraint-alt-domain+Dual_Intf.gen.cs
// Generated from constraint-alt-domain+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

public interface ItestCnstAltDmnDual
{
  ItestRefCnstAltDmnDual<ItestDomCnstAltDmnDual> AsRefCnstAltDmnDual { get; }
  ItestCnstAltDmnDualObject AsCnstAltDmnDual { get; }
}

public interface ItestCnstAltDmnDualObject
{
}

public interface ItestRefCnstAltDmnDual<TRef>
{
  TRef Asref { get; }
  ItestRefCnstAltDmnDualObject<TRef> AsRefCnstAltDmnDual { get; }
}

public interface ItestRefCnstAltDmnDualObject<TRef>
{
}

public interface ItestDomCnstAltDmnDual
  : IGqlpDomainString
{
}
