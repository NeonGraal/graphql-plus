//HintName: test_constraint-field-domain+Input_Impl.gen.cs
// Generated from constraint-field-domain+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Input;

public class testCnstFieldDmnInp
  : testRefCnstFieldDmnInp
  , ItestCnstFieldDmnInp
{
  public testCnstFieldDmnInp CnstFieldDmnInp { get; set; }
}

public class testRefCnstFieldDmnInp<Tref>
  : ItestRefCnstFieldDmnInp<Tref>
{
  public Tref field { get; set; }
  public testRefCnstFieldDmnInp RefCnstFieldDmnInp { get; set; }
}

public class testDomCnstFieldDmnInp
  : DomainString
  , ItestDomCnstFieldDmnInp
{
}
