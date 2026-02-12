//HintName: test_constraint-field-domain+Dual_Intf.gen.cs
// Generated from constraint-field-domain+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Dual;

public interface ItestCnstFieldDmnDual
  : ItestRefCnstFieldDmnDual<ItestDomCnstFieldDmnDual>
{
  ItestCnstFieldDmnDualObject AsCnstFieldDmnDual { get; }
}

public interface ItestCnstFieldDmnDualObject
  : ItestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>
{
}

public interface ItestRefCnstFieldDmnDual<TRef>
{
  ItestRefCnstFieldDmnDualObject<TRef> AsRefCnstFieldDmnDual { get; }
}

public interface ItestRefCnstFieldDmnDualObject<TRef>
{
  TRef Field { get; }
}

public interface ItestDomCnstFieldDmnDual
  : IDomainString
{
}
