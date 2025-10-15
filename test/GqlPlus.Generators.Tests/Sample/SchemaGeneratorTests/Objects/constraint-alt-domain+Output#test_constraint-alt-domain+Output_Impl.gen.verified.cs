//HintName: test_constraint-alt-domain+Output_Impl.gen.cs
// Generated from constraint-alt-domain+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Output;

public class OutputtestCnstAltDmnOutp
  : ItestCnstAltDmnOutp
{
  public RefCnstAltDmnOutp<DomCnstAltDmnOutp> AsRefCnstAltDmnOutp { get; set; }
}

public class OutputtestRefCnstAltDmnOutp<Tref>
  : ItestRefCnstAltDmnOutp<Tref>
{
  public Tref Asref { get; set; }
}

public class DomaintestDomCnstAltDmnOutp
  : ItestDomCnstAltDmnOutp
{
}
