//HintName: test_constraint-field-domain+Output_Impl.gen.cs
// Generated from constraint-field-domain+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Output;

public class testCnstFieldDmnOutp
  : testRefCnstFieldDmnOutp<ItestDomCnstFieldDmnOutp>
  , ItestCnstFieldDmnOutp
{
  public ItestCnstFieldDmnOutpObject AsCnstFieldDmnOutp { get; set; }
}

public class testRefCnstFieldDmnOutp<TRef>
  : ItestRefCnstFieldDmnOutp<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldDmnOutpObject AsRefCnstFieldDmnOutp { get; set; }
}

public class testDomCnstFieldDmnOutp
  : DomainString
  , ItestDomCnstFieldDmnOutp
{
}
