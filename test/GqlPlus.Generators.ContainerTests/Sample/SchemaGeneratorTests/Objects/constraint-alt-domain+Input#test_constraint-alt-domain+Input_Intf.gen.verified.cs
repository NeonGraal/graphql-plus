//HintName: test_constraint-alt-domain+Input_Intf.gen.cs
// Generated from constraint-alt-domain+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

public interface ItestCnstAltDmnInp
{
  ItestRefCnstAltDmnInp<ItestDomCnstAltDmnInp> AsRefCnstAltDmnInp { get; }
  ItestCnstAltDmnInpObject AsCnstAltDmnInp { get; }
}

public interface ItestCnstAltDmnInpObject
{
}

public interface ItestRefCnstAltDmnInp<Tref>
{
  Tref Asref { get; }
  ItestRefCnstAltDmnInpObject AsRefCnstAltDmnInp { get; }
}

public interface ItestRefCnstAltDmnInpObject<Tref>
{
}

public interface ItestDomCnstAltDmnInp
  : IDomainString
{
}
