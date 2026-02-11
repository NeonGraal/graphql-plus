//HintName: test_constraint-field-domain+Input_Intf.gen.cs
// Generated from constraint-field-domain+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Input;

public interface ItestCnstFieldDmnInp
  : ItestRefCnstFieldDmnInp
{
  ItestCnstFieldDmnInpObject AsCnstFieldDmnInp { get; }
}

public interface ItestCnstFieldDmnInpObject
  : ItestRefCnstFieldDmnInpObject
{
}

public interface ItestRefCnstFieldDmnInp<Tref>
{
  ItestRefCnstFieldDmnInpObject AsRefCnstFieldDmnInp { get; }
}

public interface ItestRefCnstFieldDmnInpObject<Tref>
{
  Tref Field { get; }
}

public interface ItestDomCnstFieldDmnInp
  : IDomainString
{
}
