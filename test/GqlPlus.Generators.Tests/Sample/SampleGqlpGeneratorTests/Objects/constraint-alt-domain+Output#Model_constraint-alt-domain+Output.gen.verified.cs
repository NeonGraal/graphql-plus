//HintName: Model_constraint-alt-domain+Output.gen.cs
// Generated from constraint-alt-domain+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_constraint_alt_domain_Output;

public interface ICnstAltDmnOutp
{
  RefCnstAltDmnOutp<DomCnstAltDmnOutp> AsRefCnstAltDmnOutp { get; }
}
public class OutputCnstAltDmnOutp
  : ICnstAltDmnOutp
{
  public RefCnstAltDmnOutp<DomCnstAltDmnOutp> AsRefCnstAltDmnOutp { get; set; }
}

public interface IRefCnstAltDmnOutp<Tref>
{
  Tref Asref { get; }
}
public class OutputRefCnstAltDmnOutp<Tref>
  : IRefCnstAltDmnOutp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IDomCnstAltDmnOutp
{
}
public class DomainDomCnstAltDmnOutp
  : IDomCnstAltDmnOutp
{
}
