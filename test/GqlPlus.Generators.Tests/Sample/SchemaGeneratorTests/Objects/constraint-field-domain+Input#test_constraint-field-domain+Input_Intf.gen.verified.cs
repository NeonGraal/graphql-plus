//HintName: test_constraint-field-domain+Input_Intf.gen.cs
// Generated from constraint-field-domain+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Input;

public interface ItestCnstFieldDmnInp
  : ItestRefCnstFieldDmnInp
{
  public testCnstFieldDmnInp CnstFieldDmnInp { get; set; }
}

public interface ItestCnstFieldDmnInpField
  : ItestRefCnstFieldDmnInpField
{
}

public interface ItestRefCnstFieldDmnInp<Tref>
{
  public testRefCnstFieldDmnInp RefCnstFieldDmnInp { get; set; }
}

public interface ItestRefCnstFieldDmnInpField<Tref>
{
  public Tref field { get; set; }
}

public interface ItestDomCnstFieldDmnInp
  : IDomainString
{
}
