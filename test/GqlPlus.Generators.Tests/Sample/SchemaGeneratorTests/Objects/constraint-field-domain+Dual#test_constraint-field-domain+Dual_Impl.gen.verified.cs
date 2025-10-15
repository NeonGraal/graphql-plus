//HintName: test_constraint-field-domain+Dual_Impl.gen.cs
// Generated from constraint-field-domain+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Dual;

public class DualtestCnstFieldDmnDual
  : DualtestRefCnstFieldDmnDual
  , ItestCnstFieldDmnDual
{
}

public class DualtestRefCnstFieldDmnDual<Tref>
  : ItestRefCnstFieldDmnDual<Tref>
{
  public Tref field { get; set; }
}

public class DomaintestDomCnstFieldDmnDual
  : ItestDomCnstFieldDmnDual
{
}
