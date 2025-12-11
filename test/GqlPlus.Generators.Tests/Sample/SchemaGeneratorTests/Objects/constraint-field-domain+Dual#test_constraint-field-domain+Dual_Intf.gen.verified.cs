//HintName: test_constraint-field-domain+Dual_Intf.gen.cs
// Generated from constraint-field-domain+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Dual;

public interface ItestCnstFieldDmnDual
  : ItestRefCnstFieldDmnDual
{
  public testCnstFieldDmnDual CnstFieldDmnDual { get; set; }
}

public interface ItestCnstFieldDmnDualField
  : ItestRefCnstFieldDmnDualField
{
}

public interface ItestRefCnstFieldDmnDual<Tref>
{
  public testRefCnstFieldDmnDual RefCnstFieldDmnDual { get; set; }
}

public interface ItestRefCnstFieldDmnDualField<Tref>
{
  public Tref field { get; set; }
}

public interface ItestDomCnstFieldDmnDual
  : IDomainString
{
}
