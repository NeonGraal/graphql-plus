//HintName: test_constraint-alt-domain+Input_Intf.gen.cs
// Generated from constraint-alt-domain+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

public interface ItestCnstAltDmnInp
{
  public testRefCnstAltDmnInp<testDomCnstAltDmnInp> AsRefCnstAltDmnInp { get; set; }
  public testCnstAltDmnInp CnstAltDmnInp { get; set; }
}

public interface ItestCnstAltDmnInpObject
{
}

public interface ItestRefCnstAltDmnInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltDmnInp RefCnstAltDmnInp { get; set; }
}

public interface ItestRefCnstAltDmnInpObject<Tref>
{
}

public interface ItestDomCnstAltDmnInp
  : IDomainString
{
}
