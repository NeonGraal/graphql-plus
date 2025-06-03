//HintName: Model_constraint-field-domain+Output.gen.cs
// Generated from constraint-field-domain+Output.graphql+

/*
*/

namespace GqlTest.Model_constraint_field_domain_Output;

public interface ICnstFieldDmnOutp
  : IRefCnstFieldDmnOutp
{
}
public class OutputCnstFieldDmnOutp
  : OutputRefCnstFieldDmnOutp
  , ICnstFieldDmnOutp
{
}

public interface IRefCnstFieldDmnOutp<Tref>
{
  Tref field { get; }
}
public class OutputRefCnstFieldDmnOutp<Tref>
  : IRefCnstFieldDmnOutp<Tref>
{
  public Tref field { get; set; }
}

public interface IDomCnstFieldDmnOutp
{
}
public class DomainDomCnstFieldDmnOutp
  : IDomCnstFieldDmnOutp
{
}
