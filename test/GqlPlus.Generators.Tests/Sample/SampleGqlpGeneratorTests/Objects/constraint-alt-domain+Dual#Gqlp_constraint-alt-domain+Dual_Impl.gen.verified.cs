//HintName: Gqlp_constraint-alt-domain+Dual_Impl.gen.cs
// Generated from constraint-alt-domain+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_alt_domain_Dual;
public class DualCnstAltDmnDual
  : ICnstAltDmnDual
{
  public RefCnstAltDmnDual<DomCnstAltDmnDual> AsRefCnstAltDmnDual { get; set; }
}
public class DualRefCnstAltDmnDual<Tref>
  : IRefCnstAltDmnDual<Tref>
{
  public Tref Asref { get; set; }
}
public class DomainDomCnstAltDmnDual
  : IDomCnstAltDmnDual
{
}
