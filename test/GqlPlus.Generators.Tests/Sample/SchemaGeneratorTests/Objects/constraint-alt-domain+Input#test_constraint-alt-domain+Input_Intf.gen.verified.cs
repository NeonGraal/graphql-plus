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

public interface ItestCnstAltDmnInpField
{
}

public interface ItestRefCnstAltDmnInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltDmnInp RefCnstAltDmnInp { get; set; }
}

public interface ItestRefCnstAltDmnInpField<Tref>
{
}

public interface ItestDomCnstAltDmnInp
  : IDomainString
{
}
