//HintName: Gqlp_constraint-field-domain+Input_Impl.gen.cs
// Generated from constraint-field-domain+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_field_domain_Input;

public class InputCnstFieldDmnInp
  : InputRefCnstFieldDmnInp
  , ICnstFieldDmnInp
{
}

public class InputRefCnstFieldDmnInp<Tref>
  : IRefCnstFieldDmnInp<Tref>
{
  public Tref field { get; set; }
}

public class DomainDomCnstFieldDmnInp
  : IDomCnstFieldDmnInp
{
}
