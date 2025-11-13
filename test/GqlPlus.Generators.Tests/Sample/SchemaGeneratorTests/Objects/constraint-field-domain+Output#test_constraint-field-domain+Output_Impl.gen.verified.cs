//HintName: test_constraint-field-domain+Output_Impl.gen.cs
// Generated from constraint-field-domain+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Output;

public class testCnstFieldDmnOutp
  : testRefCnstFieldDmnOutp
  , ItestCnstFieldDmnOutp
{
  public testCnstFieldDmnOutp CnstFieldDmnOutp { get; set; }
}

public class testRefCnstFieldDmnOutp<Tref>
  : ItestRefCnstFieldDmnOutp<Tref>
{
  public Tref field { get; set; }
  public testRefCnstFieldDmnOutp RefCnstFieldDmnOutp { get; set; }
}

public class testDomCnstFieldDmnOutp
  : ItestDomCnstFieldDmnOutp
{
}
