//HintName: Gqlp_constraint-alt-domain+Input_Impl.gen.cs
// Generated from constraint-alt-domain+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_alt_domain_Input;
public class InputCnstAltDmnInp
  : ICnstAltDmnInp
{
  public RefCnstAltDmnInp<DomCnstAltDmnInp> AsRefCnstAltDmnInp { get; set; }
}
public class InputRefCnstAltDmnInp<Tref>
  : IRefCnstAltDmnInp<Tref>
{
  public Tref Asref { get; set; }
}
public class DomainDomCnstAltDmnInp
  : IDomCnstAltDmnInp
{
}
