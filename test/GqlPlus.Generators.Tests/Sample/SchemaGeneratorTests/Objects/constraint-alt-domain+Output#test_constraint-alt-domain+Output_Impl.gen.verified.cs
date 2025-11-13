//HintName: test_constraint-alt-domain+Output_Impl.gen.cs
// Generated from constraint-alt-domain+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Output;

public class testCnstAltDmnOutp
  : ItestCnstAltDmnOutp
{
  public testRefCnstAltDmnOutp<testDomCnstAltDmnOutp> AsRefCnstAltDmnOutp { get; set; }
  public testCnstAltDmnOutp CnstAltDmnOutp { get; set; }
}

public class testRefCnstAltDmnOutp<Tref>
  : ItestRefCnstAltDmnOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltDmnOutp RefCnstAltDmnOutp { get; set; }
}

public class testDomCnstAltDmnOutp
  : ItestDomCnstAltDmnOutp
{
}
