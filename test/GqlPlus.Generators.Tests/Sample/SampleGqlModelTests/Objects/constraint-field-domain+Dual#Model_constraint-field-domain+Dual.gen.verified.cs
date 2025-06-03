//HintName: Model_constraint-field-domain+Dual.gen.cs
// Generated from constraint-field-domain+Dual.graphql+

/*
*/

namespace GqlTest.Model_constraint_field_domain_Dual;

public interface ICnstFieldDmnDual
  : IRefCnstFieldDmnDual
{
}
public class DualCnstFieldDmnDual
  : DualRefCnstFieldDmnDual
  , ICnstFieldDmnDual
{
}

public interface IRefCnstFieldDmnDual<Tref>
{
  Tref field { get; }
}
public class DualRefCnstFieldDmnDual<Tref>
  : IRefCnstFieldDmnDual<Tref>
{
  public Tref field { get; set; }
}

public interface IDomCnstFieldDmnDual
{
}
public class DomainDomCnstFieldDmnDual
  : IDomCnstFieldDmnDual
{
}
