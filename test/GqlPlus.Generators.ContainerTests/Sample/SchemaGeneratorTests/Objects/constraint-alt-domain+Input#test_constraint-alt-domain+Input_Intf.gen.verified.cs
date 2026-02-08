//HintName: test_constraint-alt-domain+Input_Intf.gen.cs
// Generated from constraint-alt-domain+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

public interface ItestCnstAltDmnInp
{
  public ItestRefCnstAltDmnInp<ItestDomCnstAltDmnInp> AsRefCnstAltDmnInp { get; set; }
  public ItestCnstAltDmnInpObject AsCnstAltDmnInp { get; set; }
}

public interface ItestCnstAltDmnInpObject
{
}

public interface ItestRefCnstAltDmnInp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefCnstAltDmnInpObject AsRefCnstAltDmnInp { get; set; }
}

public interface ItestRefCnstAltDmnInpObject<Tref>
{
}

public interface ItestDomCnstAltDmnInp
  : IDomainString
{
}
