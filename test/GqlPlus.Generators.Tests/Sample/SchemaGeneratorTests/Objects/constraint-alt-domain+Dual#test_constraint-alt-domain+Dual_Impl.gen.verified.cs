//HintName: test_constraint-alt-domain+Dual_Impl.gen.cs
// Generated from constraint-alt-domain+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

public class testCnstAltDmnDual
  : ItestCnstAltDmnDual
{
  public RefCnstAltDmnDual<DomCnstAltDmnDual> AsRefCnstAltDmnDual { get; set; }
}

public class testRefCnstAltDmnDual<Tref>
  : ItestRefCnstAltDmnDual<Tref>
{
  public Tref Asref { get; set; }
}

public class testDomCnstAltDmnDual
  : ItestDomCnstAltDmnDual
{
}
