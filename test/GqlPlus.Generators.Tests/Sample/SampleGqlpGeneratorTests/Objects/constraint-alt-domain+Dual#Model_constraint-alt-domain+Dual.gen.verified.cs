//HintName: Model_constraint-alt-domain+Dual.gen.cs
// Generated from constraint-alt-domain+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_constraint_alt_domain_Dual;

public interface ICnstAltDmnDual
{
  RefCnstAltDmnDual<DomCnstAltDmnDual> AsRefCnstAltDmnDual { get; }
}
public class DualCnstAltDmnDual
  : ICnstAltDmnDual
{
  public RefCnstAltDmnDual<DomCnstAltDmnDual> AsRefCnstAltDmnDual { get; set; }
}

public interface IRefCnstAltDmnDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefCnstAltDmnDual<Tref>
  : IRefCnstAltDmnDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IDomCnstAltDmnDual
{
}
public class DomainDomCnstAltDmnDual
  : IDomCnstAltDmnDual
{
}
