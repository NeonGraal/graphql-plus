//HintName: test_constraint-field-domain+Output_Impl.gen.cs
// Generated from constraint-field-domain+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Output;

public class OutputtestCnstFieldDmnOutp
  : OutputtestRefCnstFieldDmnOutp
  , ItestCnstFieldDmnOutp
{
}

public class OutputtestRefCnstFieldDmnOutp<Tref>
  : ItestRefCnstFieldDmnOutp<Tref>
{
  public Tref field { get; set; }
}

public class DomaintestDomCnstFieldDmnOutp
  : ItestDomCnstFieldDmnOutp
{
}
