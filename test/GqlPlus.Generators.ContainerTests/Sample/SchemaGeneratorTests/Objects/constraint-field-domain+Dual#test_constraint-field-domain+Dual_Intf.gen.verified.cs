//HintName: test_constraint-field-domain+Dual_Intf.gen.cs
// Generated from constraint-field-domain+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Dual;

public interface ItestCnstFieldDmnDual
  : ItestRefCnstFieldDmnDual
{
}

public interface ItestCnstFieldDmnDualObject
  : ItestRefCnstFieldDmnDualObject
{
}

public interface ItestRefCnstFieldDmnDual<Tref>
{
}

public interface ItestRefCnstFieldDmnDualObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestDomCnstFieldDmnDual
  : IDomainString
{
}
