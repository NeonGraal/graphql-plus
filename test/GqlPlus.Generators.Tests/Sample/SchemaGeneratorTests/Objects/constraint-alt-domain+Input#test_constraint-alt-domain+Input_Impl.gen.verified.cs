//HintName: test_constraint-alt-domain+Input_Impl.gen.cs
// Generated from constraint-alt-domain+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

public class InputtestCnstAltDmnInp
  : ItestCnstAltDmnInp
{
  public RefCnstAltDmnInp<DomCnstAltDmnInp> AsRefCnstAltDmnInp { get; set; }
}

public class InputtestRefCnstAltDmnInp<Tref>
  : ItestRefCnstAltDmnInp<Tref>
{
  public Tref Asref { get; set; }
}

public class DomaintestDomCnstAltDmnInp
  : ItestDomCnstAltDmnInp
{
}
