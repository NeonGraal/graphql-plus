//HintName: test_constraint-alt-domain+Dual_Impl.gen.cs
// Generated from constraint-alt-domain+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

public class testCnstAltDmnDual
  : ItestCnstAltDmnDual
{
  public ItestRefCnstAltDmnDual<ItestDomCnstAltDmnDual> AsRefCnstAltDmnDual { get; set; }
  public ItestCnstAltDmnDualObject AsCnstAltDmnDual { get; set; }
}

public class testRefCnstAltDmnDual<TRef>
  : ItestRefCnstAltDmnDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltDmnDualObject AsRefCnstAltDmnDual { get; set; }
}

public class testDomCnstAltDmnDual
  : DomainString
  , ItestDomCnstAltDmnDual
{
}
