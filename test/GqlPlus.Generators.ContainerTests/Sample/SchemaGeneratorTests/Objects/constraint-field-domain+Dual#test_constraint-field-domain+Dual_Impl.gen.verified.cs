//HintName: test_constraint-field-domain+Dual_Impl.gen.cs
// Generated from constraint-field-domain+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Dual;

public class testCnstFieldDmnDual
  : testRefCnstFieldDmnDual<ItestDomCnstFieldDmnDual>
  , ItestCnstFieldDmnDual
{
}

public class testRefCnstFieldDmnDual<TRef>
  : ItestRefCnstFieldDmnDual<TRef>
{
  public TRef Field { get; set; }
}

public class testDomCnstFieldDmnDual
  : GqlpDomainString
  , ItestDomCnstFieldDmnDual
{
}
