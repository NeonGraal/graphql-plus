//HintName: test_constraint-field-domain+Output_Impl.gen.cs
// Generated from constraint-field-domain+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Output;

public class testCnstFieldDmnOutp
  : testRefCnstFieldDmnOutp
  , ItestCnstFieldDmnOutp
{
  public ItestCnstFieldDmnOutpObject AsCnstFieldDmnOutp { get; set; }
}

public class testRefCnstFieldDmnOutp<Tref>
  : ItestRefCnstFieldDmnOutp<Tref>
{
  public Tref Field { get; set; }
  public ItestRefCnstFieldDmnOutpObject AsRefCnstFieldDmnOutp { get; set; }
}

public class testDomCnstFieldDmnOutp
  : DomainString
  , ItestDomCnstFieldDmnOutp
{
}
