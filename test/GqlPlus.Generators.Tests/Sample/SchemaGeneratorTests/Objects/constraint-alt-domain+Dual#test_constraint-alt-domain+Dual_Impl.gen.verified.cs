//HintName: test_constraint-alt-domain+Dual_Impl.gen.cs
// Generated from constraint-alt-domain+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

public class testCnstAltDmnDual
  : ItestCnstAltDmnDual
{
  public testRefCnstAltDmnDual<testDomCnstAltDmnDual> AsRefCnstAltDmnDual { get; set; }
  public testCnstAltDmnDual CnstAltDmnDual { get; set; }
}

public class testRefCnstAltDmnDual<Tref>
  : ItestRefCnstAltDmnDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltDmnDual RefCnstAltDmnDual { get; set; }
}

public class testDomCnstAltDmnDual
  : DomainString
  , ItestDomCnstAltDmnDual
{
}
