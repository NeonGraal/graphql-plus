//HintName: Gqlp_constraint-field-domain+Dual_Impl.gen.cs
// Generated from constraint-field-domain+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_field_domain_Dual;
public class DualCnstFieldDmnDual
  : DualRefCnstFieldDmnDual
  , ICnstFieldDmnDual
{
}
public class DualRefCnstFieldDmnDual<Tref>
  : IRefCnstFieldDmnDual<Tref>
{
  public Tref field { get; set; }
}
public class DomainDomCnstFieldDmnDual
  : IDomCnstFieldDmnDual
{
}
