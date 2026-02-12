//HintName: test_constraint-alt-domain+Input_Impl.gen.cs
// Generated from constraint-alt-domain+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

public class testCnstAltDmnInp
  : ItestCnstAltDmnInp
{
  public ItestRefCnstAltDmnInp<ItestDomCnstAltDmnInp> AsRefCnstAltDmnInp { get; set; }
  public ItestCnstAltDmnInpObject AsCnstAltDmnInp { get; set; }
}

public class testRefCnstAltDmnInp<TRef>
  : ItestRefCnstAltDmnInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltDmnInpObject<TRef> AsRefCnstAltDmnInp { get; set; }
}

public class testDomCnstAltDmnInp
  : DomainString
  , ItestDomCnstAltDmnInp
{
}
