//HintName: test_constraint-field-domain+Input_Intf.gen.cs
// Generated from constraint-field-domain+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Input;

public interface ItestCnstFieldDmnInp
  : ItestRefCnstFieldDmnInp
{
}

public interface ItestCnstFieldDmnInpObject
  : ItestRefCnstFieldDmnInpObject
{
}

public interface ItestRefCnstFieldDmnInp<Tref>
{
}

public interface ItestRefCnstFieldDmnInpObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestDomCnstFieldDmnInp
  : IDomainString
{
}
