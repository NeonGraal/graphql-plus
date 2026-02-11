//HintName: test_constraint-field-domain+Dual_Intf.gen.cs
// Generated from constraint-field-domain+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Dual;

public interface ItestCnstFieldDmnDual
  : ItestRefCnstFieldDmnDual
{
  ItestCnstFieldDmnDualObject AsCnstFieldDmnDual { get; }
}

public interface ItestCnstFieldDmnDualObject
  : ItestRefCnstFieldDmnDualObject
{
}

public interface ItestRefCnstFieldDmnDual<Tref>
{
  ItestRefCnstFieldDmnDualObject AsRefCnstFieldDmnDual { get; }
}

public interface ItestRefCnstFieldDmnDualObject<Tref>
{
  Tref Field { get; }
}

public interface ItestDomCnstFieldDmnDual
  : IDomainString
{
}
