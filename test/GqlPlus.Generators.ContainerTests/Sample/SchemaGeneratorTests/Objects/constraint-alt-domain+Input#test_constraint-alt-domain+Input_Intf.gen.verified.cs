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

public interface ItestRefCnstAltDmnInp<TRef>
{
  TRef Asref { get; }
  ItestRefCnstAltDmnInpObject<TRef> AsRefCnstAltDmnInp { get; }
}

public interface ItestRefCnstAltDmnInpObject<TRef>
{
}

public interface ItestDomCnstAltDmnInp
  : IDomainString
{
}
