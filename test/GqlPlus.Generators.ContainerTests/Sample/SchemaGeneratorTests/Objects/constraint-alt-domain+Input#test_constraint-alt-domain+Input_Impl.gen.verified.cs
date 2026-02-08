//HintName: test_constraint-alt-domain+Input_Impl.gen.cs
// Generated from constraint-alt-domain+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

public class testCnstAltDmnInp
  : ItestCnstAltDmnInp
{
  public ItestRefCnstAltDmnInp<ItestDomCnstAltDmnInp> AsRefCnstAltDmnInp { get; set; }
}

public class testRefCnstAltDmnInp<Tref>
  : ItestRefCnstAltDmnInp<Tref>
{
  public Tref Asref { get; set; }
}

public class testDomCnstAltDmnInp
  : DomainString
  , ItestDomCnstAltDmnInp
{
}
